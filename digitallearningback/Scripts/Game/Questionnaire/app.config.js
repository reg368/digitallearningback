'use strict';

angular.
    module('QuestionnaireApp').
  config(['$locationProvider' ,'$routeProvider',
    function config($locationProvider, $routeProvider) {
      $locationProvider.hashPrefix('!');

      $routeProvider.
          when('/questionnaireIndex', {
            template: '<questionnaire-index></questionnaire-index>'
        }).
          when('/questionnaireDetail/:current_index', {
            template: '<questionnaire-detail></questionnaire-detail>'
        }).
          when('/questionnaireEnd', {
              template: '<questionnaire-end></questionnaire-end>'
        }).
        otherwise('/questionnaireIndex');
    }
  ]);
