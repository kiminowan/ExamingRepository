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
    translate: ''
  },
  tap_ch: function (e) {
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
  onLoad: function (options) {
    console.log(this.data.step)
    var that = this;
    wx.getStorage({
      key: 'token',
      success: function (res) {
        wx.request({
          url: 'http://localhost:13803/api/Multimedia/GetMultimedias',
          method: 'get',
          success: function (res) {
            
            console.log(res)
            console.log(that.data.step)
            that.setData({
              logs: res.data
              
            })
            that.questionLog();
          }
        })
      },
    })

  },
  //上一题按钮事件
  prevQuestion: function () {
    if (this.data.step > 1) {
      this.setData({
        step: this.data.step - 1,
        answer: false,
      })
      this.questionLog();
    }
  },
  //下一题按钮事件
  nextQuestion: function () {
    if (this.data.step < this.data.logs.length) {
      this.setData({
        step: this.data.step + 1,
        answer: false,
      })
      this.questionLog();
    }
  },
  //选项按钮事件
  answer: function (data) {
    if (data.currentTarget.dataset.answer == this.data.logs[this.data.step - 1].Answer) {
      //选对时跳转下一题
      this.nextQuestion();
    }
    else {
      //选错时显示正确答案和解析
      this.setData({
        answer: true,
        correctAnswer: this.data.logs[this.data.step - 1].Answer
      })
    }
  },
  /*questionLog: function () {
    var id = this.data.logs[this.data.step - 1].QuestionID;
    wx.getStorage({
      key: 'token',
      success: function (res) {
        wx.request({
          url: 'http://localhost:8033/api/Remember/AddRemember',
          data: {
            openID: res.data,
            questionID: id,
          },
          method: 'get',
          success: function (res) {
            console.log(res.data)
          },
        })
      },
    })
  },*/
  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }

})