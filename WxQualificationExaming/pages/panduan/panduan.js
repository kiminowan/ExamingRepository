// hotblood_gongkao/pages/answer/answer.js
const app = getApp();
Page({

    /**
     * 页面的初始数据
     */
    data: {
        question: [
            ["今天是个好日子", "halou word", "java", "javascript", 'c#'],
            ["今天是个好日子", "halou word", "java", "javascript", 'c#'],
        ], //题库
        index: 0, //选择的索引
        wrong: [], //错误
        border: '',
        num: 0,
        con: '下一题',
        isOne: true,
        isWan: false,
        iswancheng: false,
        isque: false,
        whether: false,
        correct: [], //正确
        duiList: 0, //答对的个数
        cuoList: 0, //答错的个数
        selectIndex: [{
              sureid: false
          },
          {
              sureid: false
          },
          {
              sureid: false
          },
          {
              sureid: false
          },
        ],
      step: 1,
      answer: false,
    },

    /**
     * 生命周期函数--监听页面加载
     */
    onLoad: function (options) {
        this.setData({

        })
      var that = this;
      wx.request({
        url: 'http://172.25.53.26:8033/api/QuestionApi/GetQuestions',
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

    /**
     * 生命周期函数--监听页面初次渲染完成
     */
    onReady: function () {

    },
    // 提交答卷
    submit: function (e) {
        console.log(this.data.duiList);
        console.log(this.data.cuoList);
        var num = this.data.num; //当前题目下标
        var question = this.data.question; //题库
        var duiList = this.data.duiList; //答对多少题
        var cuoList = this.data.cuoList; //答错多少题
        //获得题目对象的长度
        var arr = Object.keys(question);
        var len = arr.length;
        if ((num + 1) == len) {
            var grade = (100 / len) * duiList;
            console.log(grade);
            wx.redirectTo({
                url: '../chengjiu/chengjiu?grade=' + grade,
            })
        }
    },
    // 确认选择
    confirm: function () {
        var num = this.data.num;
        var question = this.data.question; //题库
        //获得题目对象的长度
        var arr = Object.keys(question);
        var len = arr.length;
        if ((num + 1) == len) {
            this.setData({
                iswancheng: true,
                isOne: true,
                isWan: true,
                isque: false
            })
        } else {
            this.setData({
                isOne: false,
                whether: true,
                isque: false,
                isWan: true
            })
        }

    },
    // 下一题
    next: function () {
        var num = this.data.num; //当前题目下标
        this.setData({
            num: num + 1,
            isOne: true,
            isWan: false,
            whether: false,
            index: 0
        })
    },
    // 选择答案
    selectAnswer: function (e) {
        console.log(e);
        var index1 = e.currentTarget.dataset.index - 1; //当前点击元素的自定义数据，这个很关键
        var selectIndex = this.data.selectIndex; //取到data里的selectIndex
        selectIndex[index1].sureid = !selectIndex[index1].sureid; //点击就赋相反的值
        console.log(selectIndex[index1])
        this.setData({
            selectIndex: selectIndex //将已改变属性的json数组更新
        })
        console.log(this.data.selectIndex.in_array(true))
        if (selectIndex.in_array(true) == false) {
            this.setData({
                isque: false
            })
        } else {
            var question = this.data.question; //题库
            var num = this.data.num; //当前题目下标
            var text = e.currentTarget.dataset.text; //选择的答案
            var duiList = this.data.duiList; //答对多少题
            var cuoList = this.data.cuoList; //答错多少题

            //获得题目对象的长度
            var arr = Object.keys(question);
            var len = arr.length;
            //当前答题为最后一题
            if ((num + 1) == len) {
                //判断选择的答案和正确答案是否一致
                if (text == question[num][3]) {
                    duiList = duiList + 1;
                    this.setData({
                        duiList: duiList,
                        isque: true
                    })
                } else {
                    cuoList = cuoList + 1;
                    this.setData({
                        cuoList: cuoList,
                        isque: true
                    })
                }
            } else {
                //判断选择的答案和正确答案是否一致
                if (text == question[num][3]) {
                    duiList = duiList + 1;
                    this.setData({
                        duiList: duiList,
                        isque: true
                    })
                } else {
                    cuoList = cuoList + 1;
                    this.setData({
                        cuoList: cuoList,
                        isque: true
                    })
                }
            }
        }


    },
    /**
     * 生命周期函数--监听页面显示
     */
    onShow: function () {
        this.question();
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
Array.prototype.in_array = function (element) {
    for (var i = 0; i < this.length; i++) {
        if (this[i].sureid == element) {
            return true;
        }
    }
    return false;
}