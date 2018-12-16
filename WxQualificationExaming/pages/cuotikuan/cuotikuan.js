// pages/cuotikuan/cuotikuan.js
Page({

  /**
   * 页面的初始数据
   */
  data: {

  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */

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
  //页面加载事件
  onLoad: function (options) {
    var that=this;
      wx.getStorage({
        key: 'token',
        success: function (data) {
          console.log(data.data)
          wx.request({
            url: 'http://localhost:8033/api/ErrQuestionApi/GetErrQuestions',
            method: 'get',
            data: {
              openID: data.data,
              knowledgePointID:options.id
            },
            header: {
              'content-type': 'application/json',
              'Authorization': 'BasicAuth ' + data.data
            },
            success: function (res) {
              console.log(res)
              that.setData({
                log: res.data
              })
            }
          })
        }
      })
},
//点击删除事件
  shan:function(e){
    
    
    var id = e.currentTarget.dataset.aid;
    console.log(id);
    wx.getStorage({
      key: 'token',
      success: function (data) {
        console.log(data.data)
        wx.request({
          url: 'http://localhost:8033/api/UsersApi/DeleteErro?errid=' + id,
          method: 'get',
          data: {},
          header: {
            'content-type': 'application/json',
            'Authorization': 'BasicAuth ' + data.data
          },
          success: function () {
            console.log("删除成功！");
          }
        })
      }
    })

  }
})