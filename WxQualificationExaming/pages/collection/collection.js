// pages/practice1/practice1.js
const app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    step: 1,
    answer: false,
    windowWidth: wx.getSystemInfoSync().windowWidth,
    staus: 1,
    translate: '',
    showLeft1: false,
    multi: '',
    showModal: false,
    show: false,
  },
  tap_ch: function(e) {
    if (this.data.open) {
      this.setData({
        translate: 'transform: translateX(0px)'
      })
      this.data.open = false;
    } else {
      this.setData({
        translate: 'transform: translateX(' + this.data.windowWidth * 0.75 + 'px)'
      })
      this.data.open = true;
    }
  },
  /**
   * 生命周期函数--监听页面加载
   */

  checkboxChange(e) {
    console.log('checkbox发生change事件，携带value值为：', e.detail.value.sort().join(''))
    this.setData({
      multi: e.detail.value.sort().join('')
    })
  },
  onLoad: function(options) {
    if (options.num != undefined) {
      this.setData({
        step: parseInt(options.num)
      })
    }
    var that = this;
    wx.getStorage({
      key: 'token',
      success: function(res) {
        wx.request({
          url: 'http://localhost:8033/api/CollectionApi/GetQuestions',
          data: {
            openID: res.data
          },
          method: 'get',
          header: {
            'content-type': 'application/json',
            'Authorization': 'BasicAuth ' + res.data
          },
          success: function(res) {
            console.log(res.data)
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
        show: false
      })
    }
  },
  //下一题按钮事件
  nextQuestion: function() {
    if (this.data.step < this.data.logs.length) {
      this.setData({
        step: this.data.step + 1,
        answer: false,
        show: false
      })
    }
  },
  //跳转到某题
  skipQuestion: function(data) {
    this.setData({
      step: data.currentTarget.dataset.num,
      answer: false,
      show:false
    })
    this.selectComponent("#i-drawer").handleMaskClick();
  },
  //选项按钮事件
  answer: function(data) {
    this.setData({
      show: true,
    })
    if (data.currentTarget.dataset.answer == this.data.logs[this.data.step - 1].Answer) {
      this.setData({
        answer: false
      })
    } else {
      //选错时显示正确答案和解析
      this.setData({
        answer: true,
        correctAnswer: this.data.logs[this.data.step - 1].Answer
      })
    }
  },
  //多选答案
  multiAnswer: function() {
    if (this.data.multi == this.data.logs[this.data.step - 1].Answer) {} else {
      this.setData({
        answer: true,
        correctAnswer: this.data.logs[this.data.step - 1].Answer
      })
    }
  },
  onCollectionTap: function(e) {
    var that = this;
    wx.getStorage({
      key: 'token',
      success: function(res) {
        wx.request({
          url: 'http://localhost:8033/api/CollectionApi/DeleteCollection',
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
  onReady: function() {},

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function() {},

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

  },
  //抽屉插件
  toggleLeft1() {
    this.setData({
      showLeft1: !this.data.showLeft1
    });
  },
  //模态对话框
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
  }
})