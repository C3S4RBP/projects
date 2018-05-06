(function () {
    'use strict';

    angular
        .module('listmodule')
        .controller('list.controller', listController);

    listController.$inject = ['$scope', '$state',  '$mdDialog', 'home.service'];
    function listController($scope, $state, $mdDialog, homeService) {
        var vm = this;
        $scope.data = $state.params.data;
        setAllPag($scope.data);

        $scope.moreInfo = function (target) {
            var confirm = $mdDialog.confirm()
                .title(target.name + ' (' + target.id + ')', )
                .textContent(target.description)
                .ariaLabel('Lucky day')
                .ok(target.isFavorite ? 'Quitar de favoritos' : 'Agregar a favoritos')
                .cancel('Cerrar');

            $mdDialog.show(confirm).then(function () {
                target.isFavorite = target.isFavorite === undefined ? true : !target.isFavorite;
            }, function () {

            });
        };

        $scope.otherPag = function (pag) {
            var param = {
                name: $state.params.name,
                max: 10,
                min: pag.min
            };

            homeService.getCharacter(param)
                .then(function succes(response) {
                    $scope.data = response.data.data;
                }, function error(error) {
                    console.log(error);
                });
        }

        function setAllPag(data) {
            $scope.allpag = [];
            if (data.total > 10) {
                var totalPage = Math.round(data.total / 10);
                for (var i = 0; i < totalPage; i++) {
                    $scope.allpag.push(
                        { id: i, min: (i * 10), max: 10 }
                    );
                }

                angular.forEach(totalPage, function (v, k) {

                })
            } else {
                $scope.allpag.push(
                    { id: 0, min: 0, max: 10 }
                );
            }

        }
    }
})();