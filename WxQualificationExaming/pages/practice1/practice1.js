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
    collections: [],
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
          url: 'http://172.25.53.26:8033/api/QuestionApi/GetQuestions',
          data: {
            knowledgePointID: options.id
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
            for (var i = 0; i < res.data.length; i++) {
              that.data.collections.push(false)
            }
            that.questionLog();
            wx.getStorage({
              key: 'token',
              success: function(res) {
                wx.request({
                  url: 'http://172.25.53.26:8033/api/CollectionApi/GetQuestions',
                  data: {
                    openID: res.data
                  },
                  method: 'get',
                  header: {
                    'content-type': 'application/json',
                    'Authorization': 'BasicAuth ' + res.data
                  },
                  success: function(res) {
                    var collections = that.data.collections
                    for (var i = 0; i < that.data.logs.length; i++) {
                      for (var j = 0; j < res.data.length; j++) {
                        if (that.data.logs[i].QuestionID == res.data[j].QuestionID) {
                          collections[i] = true;
                        }
                      }
                    }
                    that.setData({
                      collections: collections
                    })
                    console.log(that.data.collections)
                  }
                })
              },
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
      })
      this.questionLog();
    }
  },
  //下一题按钮事件
  nextQuestion: function() {
    if (this.data.step < this.data.logs.length) {
      this.setData({
        step: this.data.step + 1,
        answer: false,
      })
      this.questionLog();
    }
  },
  //跳转到某题
  skipQuestion: function(data) {
    this.setData({
      step: data.currentTarget.dataset.num,
      answer: false,
    })
    this.selectComponent("#i-drawer").handleMaskClick();
    this.questionLog();
  },
  //选项按钮事件
  answer: function(data) {
    if (data.currentTarget.dataset.answer == this.data.logs[this.data.step - 1].Answer) {
      //选对时跳转下一题
      this.nextQuestion();
    } else {
      //选错时显示正确答案和解析
      this.errQuestionLog();
      this.setData({
        answer: true,
        correctAnswer: this.data.logs[this.data.step - 1].Answer
      })
    }
  },
  //做题记录
  questionLog: function() {
    var id = this.data.logs[this.data.step - 1].QuestionID;
    wx.getStorage({
      key: 'token',
      success: function(res) {
        wx.request({
          url: 'http://172.25.53.26:8033/api/RememberApi/AddRemember',
          header: {
            'content-type': 'application/json',
            'Authorization': 'BasicAuth ' + res.data
          },
          data: {
            openID: res.data,
            questionID: id,
          },
          method: 'get',
          success: function(res) {
            console.log(res.data)
          },
        })
      },
    })
  },
  //错题记录
  errQuestionLog: function() {
    var id = this.data.logs[this.data.step - 1].QuestionID;
    wx.getStorage({
      key: 'token',
      success: function(res) {
        wx.request({
          url: 'http://172.25.53.26:8033/api/ErrQuestionApi/AddErro',
          header: {
            'content-type': 'application/json',
            'Authorization': 'BasicAuth ' + res.data
          },
          data: {
            openID: res.data,
            questionID: id,
          },
          method: 'get',
          success: function(res) {
            console.log(res.data)
          },
        })
      },
    })
  },
  //多选答案
  multiAnswer: function() {
    if (this.data.multi == this.data.logs[this.data.step - 1].Answer) {
      this.nextQuestion();
    } else {
      this.errQuestionLog();
      this.setData({
        answer: true,
        correctAnswer: this.data.logs[this.data.step - 1].Answer
      })
    }
  },
  //收藏按钮
  onCollectionTap: function() {
    var collections = this.data.collections
    var id = this.data.logs[this.data.step - 1].QuestionID;
    console.log(collections[this.data.step - 1]) 
    console.log(this.data.step - 1)
    if (collections[this.data.step - 1]) {
      wx.getStorage({
        key: 'token',
        success: function (res) {
          wx.request({
            url: 'http://172.25.53.26:8033/api/CollectionApi/DeleteCollection',
            header: {
              'content-type': 'application/json',
              'Authorization': 'BasicAuth ' + res.data
            },
            data: {
              openID: res.data,
              questionID: id,
            },
            method: 'get',
            success: function (res) {
            },
          })
        },
      })
    } else {
      wx.getStorage({
        key: 'token',
        success: function (res) {
          wx.request({
            url: 'http://172.25.53.26:8033/api/CollectionApi/AddCollection',
            header: {
              'content-type': 'application/json',
              'Authorization': 'BasicAuth ' + res.data
            },
            data: {
              openID: res.data,
              questionID: id,
            },
            method: 'get',
            success: function (res) {
            },
          })
        },
      })
    }
    collections[this.data.step - 1] = !collections[this.data.step - 1]
    this.setData({
      collections: collections
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