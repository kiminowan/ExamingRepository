// pages/practice/practice.js
const util = require('../../utils/util.js')
Page({

  /**
   * 页面的初始数据
   */
  data: {
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    wx.showModal({
      title: '提示',
      content: '是否回到上次做题页面',
      success: function (res) {
        if (res.confirm) {
          //这里是点击了确定以后
          wx.getStorage({
            key: 'token',
            success: function(res) {
              wx.request({
                url: 'http://localhost:8033/api/QuestionApi/GetRememberQuestion',
                data: {
                  openID: res.data
                },
                method: 'get',
                header: {
                  'content-type': 'application/json',
                  'Authorization': 'BasicAuth ' + res.data
                },
                success: function (res) {
                  console.log(res)
                  wx.navigateTo({
                    url: '/pages/practice1/practice1?id=' + res.data.KnowledgePointID + '&num=' + res.data.Num,
                  })
                }
              })
              
            },
          })
        } 
      }
    })
    var that = this;
    wx.request({
      url: 'http://localhost:8033/api/KnowledgePointApi/GetKnowledgePoints',
      method: 'get',
      success: function (res) {
        console.log(res)
        that.setData({
          practice: res.data
        })
      }
    })
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

  },
  zsd1: function (data) {
    console.log(data.currentTarget.dataset.src)
   wx.navigateTo({
     url: '/pages/practice1/practice1?id=' + data.currentTarget.dataset.src,
   })
  }
})