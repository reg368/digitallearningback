'use strict';

// Register `questionnaireIndex` component, along with its associated controller and template
angular.
    module('questionnaireDetail').
    component('questionnaireDetail', {
        templateUrl: '/Scripts/Game/Questionnaire/questionnaireDetail/questionnaire-detail.template.html',
        controller: function QuestionnaireDetailController($scope, $http, $location, $routeParams) {

            var self = this;

            $scope.nextBtnIsDisabled = false;
            var current_index = $routeParams.current_index;
            current_index = current_index.replace(":", '');
            var next = parseInt(current_index) + 1;

            $http.post('/Game/Questionnaire/GETQuestionnaire_info',
                { "current_index": current_index }).
                success(function (data, status, headers, config) {

                    self.total_question = data.total_question;
                    self.current_index = data.current_index;

                    if (self.total_question < self.current_index) {
                        $location.path('/questionnaireEnd/');
                    }

                    self.questionnaire_Main = data.questionnaire_Main;
                    self.option_list = data.option_list;

                }).
                error(function (data, status, headers, config) {
                    console.log('error data : ' + data);
                    console.log('error status : ' + status);
                });

            $scope.next = function () {

                $scope.nextBtnIsDisabled = true;
                var selected = $("input[name='options']:checked");

                if (selected.length > 0) {

                    var userid = $('#userid').val();
                    var main_id = self.questionnaire_Main.id;
                    var optionid = selected.val();
               
                    $http.post('/Game/Questionnaire/PUTQuestionnaire_data',
                        { "userid": userid, "main_id": main_id, "option_id": optionid }).
                        success(function (data, status, headers, config) {
                            $location.path('/questionnaireDetail/:' + next);
                        }).
                        error(function (data, status, headers, config) {
                            console.log('error data : ' + data);
                            console.log('error status : ' + status);
                            alert('發生了問題 , 請再試一次或聯絡助教');
                            $scope.nextBtnIsDisabled = false;
                            return false;
                        });

                } else {
                    $scope.nextBtnIsDisabled = false;
                    alert('請選擇其中一個選項');
                    return false;
                }
            }
        }
  });
