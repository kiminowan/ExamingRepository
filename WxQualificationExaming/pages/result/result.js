// pages/result/result.js
Page({
  btn_index: function() {
    wx.redirectTo({
      //详细信息
      url: "/pages/choose1/choose1"
    })
  },
  btn_history: function() {
    wx.redirectTo({
      //详细信息
      url: "/pages/lishi/lishi"
    })
  },
  /**
   * 页面的初始数据
   */
  data: {

  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var that = this;
    wx.getStorage({
      key: 'token',
      success: function(res) {
        wx.request({
          url: 'http://localhost:8033/api/ScoreApi/GetScoreByid',
          header: {
            'content-type': 'application/json',
            'Authorization': 'BasicAuth ' + res.data
          },
          data: {
            id: options.id,
          },
          method: 'get',
          success: function(res) {
            that.setData({
              score: res.data[0].Scores,
              time: res.data[0].CreateTime,
              examName: res.data[0].isRandom ? '随机抽题' : res.data[0].ExamName
            })
          },
        })
      },
    })
    console.log(options.id)
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