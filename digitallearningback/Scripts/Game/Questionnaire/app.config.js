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
          when('/questionnaireDetail/:qid', {
            template: '<questionnaire-detail></questionnaire-detail>'
        }).
        otherwise('/questionnaireIndex');
    }
  ]);
