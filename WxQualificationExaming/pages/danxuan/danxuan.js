// pages/danxuan/danxuan.js
Page({

  data: {

  },
  onLoad: function () {
    var that = this;
    wx.request({
      url: 'http://localhost:60036/api/Default/show',
      method: 'get',
      success: function (q) {
        console.log(q.data)
        that.setData({
          danxuan: q.data
        })
      }
    })
  }
})