// pages/errDetail/errDetail.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    showLeft1: false,
    showModal: false,
    windowWidth: wx.getSystemInfoSync().windowWidth,
    staus: 1,
    translate: '',
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    this.setData({
      step: parseInt(options.num)
    })
    var that = this;
    wx.getStorage({
      key: 'token',
      success: function(res) {
        wx.request({
          url: 'http://localhost:8033/api/ErrQuestionApi/GetErrQuestions',
          data: {
            openID: res.data,
            knowledgePointID: options.id
          },
          method: 'get',
          header: {
            'content-type': 'application/json',
            'Authorization': 'BasicAuth ' + res.data
          },
          success: function(res) {
            that.setData({
              logs: res.data
            })
          }
        })
      },
    })
  },
  //上一题按钮事件
  prevQuestion: function() {
    if (this.data.step > 1) {
      this.setData({
        step: this.data.step - 1,
        answer: false,
      })
    }
  },
  //下一题按钮事件
  nextQuestion: function() {
    if (this.data.step < this.data.logs.length) {
      this.setData({
        step: this.data.step + 1,
        answer: false,
      })
    }
  },
  //跳转到某题
  skipQuestion: function(data) {
    this.setData({
      step: data.currentTarget.dataset.num,
      answer: false,
    })
    this.selectComponent("#i-drawer").handleMaskClick();
  },
  //抽屉插件
  toggleLeft1() {
    this.setData({
      showLeft1: !this.data.showLeft1
    });
  },
  showDialogBtn: function() {
    this.setData({
      showModal: true
    })
  },
  /**
   * 弹出框蒙层截断touchmove事件
   */
  preventTouchMove: function() {},
  /**
   * 隐藏模态对话框
   */
  hideModal: function() {
    this.setData({
      showModal: false
    });
  },
  //删除事件
  deleteQuestion: function(e) {
    var that = this;
    wx.getStorage({
      key: 'token',
      success: function(res) {
        wx.request({
          url: 'http://localhost:8033/api/ErrQuestionApi/DeleteErro',
          method: 'get',
          data: {
            questionID: e.currentTarget.dataset.id,
            openID: res.data
          },
          header: {
            'content-type': 'application/json',
            'Authorization': 'BasicAuth ' + res.data
          },
          success: function(res) {
            if (res.data > 0) {
              that.data.logs.splice(e.currentTarget.dataset.index, 1)
              that.setData({
                logs: that.data.logs
              })
              if (e.currentTarget.dataset.index == that.data.logs.length) {
                console.log(that.data.step)
                if (that.data.step != 1) {
                  that.setData({
                    step: that.data.step - 1
                  })
                }
              }
            }
          }
        })
      },
    })
  },
  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function() {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function() {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function() {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function() {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function() {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function() {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function() {

  }
})