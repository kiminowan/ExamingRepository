// pages/practice1/practice1.js
var timer = require('../../utils/wxTimer.js')
const app = getApp()
Page({

  /**
   * 页面的初始数据
   */
  data: {
    step: 1,
    showLeft1: false,
    wxTimerList: {},
    answers: [],
    isAnalized:false
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    /*console.log(this.data.step)*/
    var that = this;
    wx.request({
      url: 'http://localhost:8033/api/QuestionApi/GetQuestions',
      data: {
        knowledgePointID: 1
      },
      method: 'get',
      success: function(res) {
        console.log(res)
        for (var i = 0; i < res.data.length; i++) {
          that.data.answers.push({
            answer: '',
            show: false
          })
        }
        console.log(that.data.answers)
        that.setData({
          logs: res.data
        })
        var wxTimer = new timer({
          beginTime: "00:20:00",
          complete: function() {
            console.log("完成了")
          }
        })
        wxTimer.start(that);
      }
    })
  },
  checkboxChange(e) {
    console.log('checkbox发生change事件，携带value值为：', e.detail.value.sort().join(''));
    var answerList = this.data.answers
    answerList[this.data.step - 1].answer = e.detail.value.sort().join('');
    answerList[this.data.step - 1].show = answerList[this.data.step - 1].answer.length > 0;
    this.setData({
      answers: answerList
    })
  },
  //上一题按钮事件
  prevQuestion: function() {
    if (this.data.step > 1) {
      this.setData({
        step: this.data.step - 1,
      })
    }
  },
  //下一题按钮事件
  nextQuestion: function() {
    if (this.data.step < this.data.logs.length) {
      this.setData({
        step: this.data.step + 1,
      })
    }
  },
  //跳转到某题
  skipQuestion: function(data) {
    this.setData({
      step: data.currentTarget.dataset.num,
    })
    this.selectComponent("#i-drawer").handleMaskClick();
  },
  //选项按钮事件
  answer: function(data) {
    var answerList = this.data.answers
    answerList[this.data.step - 1].answer = data.currentTarget.dataset.answer;
    if (answerList[this.data.step - 1].show == false) {
      answerList[this.data.step - 1].show = true;
    }
    this.setData({
      answers: answerList
    })
  },
  //交卷事件
  examSubmit: function() {
    var score = 0;
    var maxscore=0;
    for (var i = 0; i < this.data.logs.length; i++) {
      switch (this.data.logs[i].TypeID) {
        case 1:
          maxscore += 3;
          break;
        case 2:
          maxscore += 3;
          break;
        case 3:
          maxscore += 4;
          break;
        case 4:
          maxscore += 7;
          break;
        case 5:
          maxscore += 8;
          break;
      }
      if (this.data.logs[i].Answer == this.data.answers[i].answer) {
        switch (this.data.logs[i].TypeID) {
          case 1:
            score += 3;
            break;
          case 2:
            score += 3;
            break;
          case 3:
            score += 4;
            break;
          case 4:
            score += 7;
            break;
          case 5:
            score += 8;
            break;
        }
      }
    }
    console.log('总分' + maxscore + ' 得分' + score)
  },
  showDialogBtn: function () {
    this.setData({
      showModal: true,
      isAnalized:true
    })
  },
  hideModal: function () {
    this.setData({
      showModal: false
    });
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
  //抽屉插件
  toggleLeft1() {
    this.setData({
      showLeft1: !this.data.showLeft1
    });
  }
})