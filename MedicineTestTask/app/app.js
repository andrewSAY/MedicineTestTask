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
                        url: '/list?from&to&col&dir',
                        templateUrl: '/app/components/patienteditor/PatientGrid.html',                        
                        controller: 'PatientGridController',
                        params: {
                            from: undefined, to: undefined, col: undefined,
                            dir: Patienteditor.global.sortDirection.ask
                        }
                    },
                    {
                        name: 'patienteditor.addnew',
                        url: '/addnew',
                        templateUrl: '/app/components/patienteditor/AddNew.html',
                        controller: 'AddNewController'
                    },
                ];
                states.forEach(function (state) {
                    $stateProvider.state(state);
                });
            }
        ]);
})();