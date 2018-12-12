//app.js
App({
  onLaunch: function () {
    // 展示本地存储能力
    var logs = wx.getStorageSync('logs') || []
    logs.unshift(Date.now())
    wx.setStorageSync('logs', logs)

    // 登录
    wx.login({
      success: function (res) {
        if (res.code) {
          wx.request({
            url: 'http://localhost:8033/api/KnowledgePointApi/Login',
            data: {
              code: res.code
            },
            success: function (res) {
              var set = wx.setStorage({
                key: 'token',
                data: res.data.OpenID,
                success: function (res) {

                },
                fail: function (res) { },
                complete: function (res) { },
              })
              console.log(res.data.OpenID)
            }
          })
        }
        /*
        wx.getUserInfo({
          success: function (res) {
           console.log(res)
           var set=wx.setStorage({
             key: 'username',
             data: res.userInfo.nickName,
             success: function(res) {
               
             },
             fail: function(res) {
               wx.showModal({
                 title: '提示',
                 content: '拒绝授权可能会影响部分功能使用，请设置授权',
                 confirmText: '去设置',
                 success:res=>{
                   if(res.confirm)
                   {
                      wx.openSetting({
                        
                      })
                   }
                 }
               })
             },
             complete: function(res) {},
           })
          }
        })*/
      }
    })
    // 获取用户信息
    wx.getSetting({
      success: res => {
        if (res.authSetting['scope.userInfo']) {
          // 已经授权，可以直接调用 getUserInfo 获取头像昵称，不会弹框
          wx.getUserInfo({
            success: res => {
              // 可以将 res 发送给后台解码出 unionId
              this.globalData.userInfo = res.userInfo

              // 由于 getUserInfo 是网络请求，可能会在 Page.onLoad 之后才返回
              // 所以此处加入 callback 以防止这种情况
              if (this.userInfoReadyCallback) {
                this.userInfoReadyCallback(res)
              }
            }
          })
        }
      }
    })
  },
  globalData: {
    userInfo: null
  }
})