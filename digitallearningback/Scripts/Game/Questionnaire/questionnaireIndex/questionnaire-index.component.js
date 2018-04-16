'use strict';

// Register `questionnaireIndex` component, along with its associated controller and template
angular.
    module('questionnaireIndex').
    component('questionnaireIndex', {
        templateUrl: '/Scripts/Game/Questionnaire/questionnaireIndex/questionnaire-index.template.html',
        controller: function QuestionnaireIndexController($scope, $http, $location) {

                $scope.startBtnValue = '開始';
                $scope.startBtnIsDisabled = false;

                var userid = $('#userid').val();

                $scope.statr = function () {

                    $scope.startBtnIsDisabled = true;
                    $scope.startBtnValue = '資料讀取中,請稍後...';

                    $http.post('/Game/Questionnaire/GETIsStudentMultiTestQuestionnaire',
                        { "userid": userid }).
                        success(function (data, status, headers, config) {
                            if (data.statuscode == '1') {
                                //使用者已經填寫過問卷了 
                                if (data.ismultiTest == '1') {

                                    $scope.startBtnValue = '您已經填寫過問卷摟 , 感謝您的填寫';

                                //使用者沒有寫過問卷 - 開始填寫
                                } else {
                              
                                    $location.path('/questionnaireDetail/:1');
                                }
                            }
                        }).
                        error(function (data, status, headers, config) {
                            $scope.startBtnValue = '開始失敗 , 請聯絡助教';
                        });
                }
            }
  });
