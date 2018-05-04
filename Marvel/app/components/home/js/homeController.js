(function () {
    'use strict';

    angular
        .module('homemodule')
        .controller('home.controller', homeController);

    homeController.$inject = ['$scope', 'home.constants', 'home.service', '$state'];
    function homeController($scope, homeConstants, homeService, $state) {
        $scope.data = {
            search: ''
        }

        $scope.searchCharacter = function (event) {
            if ($scope.data.search.length > 0 && event.code === "Enter") {
                var param = {
                    name: $scope.data.search,
                    max: 10,
                    min: 0
                };

                homeService.getCharacter(param)
                    .then(function succes(response) {
                        $state.go('search', {
                            name: param.name,
                            data: response.data.data
                        });
                    }, function error(error) {
                        console.log(error);
                    });
            }
        };
    }
})();