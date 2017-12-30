(function () {
    'use strict';

    angular
        .module('app')
        .controller('AddNewController', ['$scope', '$state', 'EditorService',
            function ($scope, $state, EditorService) {
                $scope.patient = {
                    FirstName: '', SecondName:'', BirthDate: new Date('1800-01-01 00:00:00')
                };
                $scope.save = function () {
                    EditorService.SaveNew(patient).then(function (responce) {
                        $state.go($scope.tabs[0].route);
                    });
                }
            }
        ]);
})();
