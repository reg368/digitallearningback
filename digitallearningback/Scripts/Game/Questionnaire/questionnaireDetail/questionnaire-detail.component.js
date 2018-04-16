'use strict';

// Register `questionnaireIndex` component, along with its associated controller and template
angular.
    module('questionnaireDetail').
    component('questionnaireDetail', {
        templateUrl: '/Scripts/Game/Questionnaire/questionnaireDetail/questionnaire-detail.template.html',
        controller: function QuestionnaireDetailController($scope, $http, $location, $routeParams) {

            var self = this;
            var current_index = $routeParams.current_index;
            current_index = current_index.replace(":", '');
            var next = parseInt(current_index) + 1;

            $http.post('/Game/Questionnaire/GETQuestionnaire_info',
                { "current_index": current_index }).
                success(function (data, status, headers, config) {

                    console.log('success data : ' + data);
                    console.log('success status : ' + status);

                    self.total_question = data.total_question;
                    self.current_index = data.current_index;
                    self.questionnaire_Main = data.questionnaire_Main;
                    self.option_list = data.option_list;

                }).
                error(function (data, status, headers, config) {
                    console.log('error data : ' + data);
                    console.log('error status : ' + status);
                });

            $scope.next = function () {
                $location.path('/questionnaireDetail/:' + next);
            }

        }
  });
