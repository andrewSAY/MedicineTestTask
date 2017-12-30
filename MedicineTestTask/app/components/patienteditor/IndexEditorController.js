(function () {
    'use strict';

    angular
        .module('app')
        .controller('IndexEditorController', ['$scope', '$state',
            function ($scope, $state) {
                $scope.selectedTab = 0;                
                $scope.tabs = [
                    { text: "All patients", icon: "group", route: "patienteditor.list"},
                    { text: "Add new one", icon: "user", route: "patienteditor.addnew"},
                ];                
                $scope.goTo = function () {
                    var routeName = $scope.tabs[$scope.selectedTab].route;
                    $state.go(routeName);
                };
                $scope.goTo();
            }
        ]);

    
})();
