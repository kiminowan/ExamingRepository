// pages/cuoti/cuoti.js
Page({

  /**
   * 页面的初始数据
   */
  data: {

  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {

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

  },
  onLoad: function(options) {
    var that = this;
    wx.getStorage({
      key: 'token',
      success: function(res) {
        wx.request({
          url: 'http://172.25.53.26:8033/api/KnowledgePointApi/GetKnowledgePointByOpenID',
          data: {
            openID: res.data
          },
          method: 'get',
          success: function(q) {
            console.log(q)
            that.setData({
              practice: q.data
            })
          }
        })
      },
    })
  },
  //注释的点击事件
  /*zsd1: function (res) {
        wx.getStorage({
          key: 'token',
          success: function (data) {
            console.log(data.data)
            wx.request({
              url: 'http://localhost:13803/api/UsersApi/GetErrQuestions?username=' + data.data,
              method: 'GET',
              data: {},
              header: {
                'content-type': 'application/json',
                'Authorization': 'BasicAuth ' + data.data
              },
              success: function (res) {
                console.log(res)
                that.setData({
                  hasList: true,
                  carts: res.data
                })
              }
            }),

              //显示收货地址
              wx.request({
              url: 'http://localhost:55345/api/flower/GetAddress?username=' + data.data,
                method: 'GET',
                data: {},
                header: {
                  'content-type': 'application/json',
                  'Authorization': 'BasicAuth ' + data.data
                },
                success: function (res) {
                  console.log(res)
                  that.setData({
                    tempInfo: res.data,
                  })
                }
              })
          }
        })
     
      
   
      this.getTotalPrice();
  },*/
  zsd1: function(e) {
    wx.navigateTo({
      //跳转到自己希望到页面
      url: '/pages/cuotikuan/cuotikuan?id=' + e.currentTarget.dataset.src,
    })
  },
})