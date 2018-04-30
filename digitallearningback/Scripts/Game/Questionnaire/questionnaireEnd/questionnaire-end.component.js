'use strict';

// Register `questionnaireIndex` component, along with its associated controller and template
angular.
    module('questionnaireEnd').
    component('questionnaireEnd', {
        templateUrl: '/Scripts/Game/Questionnaire/questionnaireEnd/questionnaire-end.template.html',
        controller: function QuestionnaireEndController($scope) {

            this.endBtnValue = '關閉視窗';

            $scope.end = function () {
                window.close();
            }
        }
  });
