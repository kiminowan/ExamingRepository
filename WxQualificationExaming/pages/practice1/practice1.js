// pages/practice1/practice1.js
const app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    step: 1,
    answer:false,
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    console.log(this.data.step)
    var that = this;
    wx.request({
      url: 'http://localhost:8033/api/KnowledgePointApi/GetQuestions',
      method: 'get',
      success: function (res) {
        console.log(res)
        console.log(that.data.step)
        that.setData({
          logs: res.data
        })
      }
    })
  },
  prevQuestion:function(){
    if (this.data.step>1){
    this.setData({
      step: this.data.step - 1,
      answer: false,
      })
    }
  },
  nextQuestion: function () {
    if (this.data.step < this.data.logs.length){
    this.setData({
      step: this.data.step + 1,
      answer:false,
      })
    }
  }, 
  answer: function (data) {
    if (data.currentTarget.dataset.answer == this.data.logs[this.data.step-1].Answer){
     this.nextQuestion();
    }
    else{
      this.setData({
        answer: true,
        correctAnswer: this.data.logs[this.data.step - 1].Answer
      })
    }
  },
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