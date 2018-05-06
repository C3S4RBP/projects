(function () {
    'use strict';

    angular
        .module('headermodule')
        .controller('header.controller', headerController);

    headerController.$inject = ['$scope', '$state', 'home.service'];
    function headerController($scope, $state, homeService) {
        var vm = this;
        $scope.search = $state.params.name;

        $scope.searchCharacter = function (event) {
            if ($scope.search.length > 0 && event.code === "Enter") {
                var param = {
                    name: $scope.search,
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