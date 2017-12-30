(function () {
    'use strict';

    angular.module('app', [
        'ui.router',
        'dx'
    ])
        .config(['$stateProvider',
            function ($stateProvider) {
                var states = [
                    {
                        name: 'patienteditor',
                        abstract: true,
                        url: '',                        
                    },
                    {
                        name: 'patienteditor.list',
                        url: '/list',
                        templateUrl: '/app/components/patienteditor/PatientGrid.html',                        
                    },
                    {
                        name: 'patienteditor.addnew',
                        url: '/addnew',
                        templateUrl: '/app/components/patienteditor/AddNew.html',
                    },
                ];
                states.forEach(function (state) {
                    $stateProvider.state(state);
                });
            }
        ]);
})();