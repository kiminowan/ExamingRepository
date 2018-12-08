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
  },
  data:{

  },
  onLoad:function(){
    var that=this;
    wx.request({
      url: 'http://localhost:13803/api/KnowledgePointApi/GetKnowledgePoint',
      method:'get',
      success:function(q){
        console.log(q)
        that.setData({
          practice:q.data
        })
      }
    })
  }
})