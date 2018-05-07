(function () {
    'use strict';

    angular
        .module('listmodule')
        .controller('list.controller', listController);

    listController.$inject = ['$scope', '$state', '$mdDialog', '$mdToast', 'home.service', 'list.constants', 'favorite.service'];
    function listController($scope, $state, $mdDialog, $mdToast, homeService, CONSTANTS, favoriteService) {
        var vm = this;
        var variusCharacters = [];
        $scope.checkedCount = 0;
        $scope.data = $state.params.data;
        setAllPag($scope.data);

        $scope.moreInfo = function (target) {
            target.isFavorite = getFavorite(target.id);
            var confirm = $mdDialog.confirm()
                .title(target.name + ' (' + target.id + ')', )
                .textContent(target.description)
                .ariaLabel('Lucky day')
                .ok(target.isFavorite ? CONSTANTS.REMOVE : CONSTANTS.ADD)
                .cancel(CONSTANTS.CLOSE);

            $mdDialog.show(confirm).then(function () {
                target.isFavorite = target.isFavorite === undefined ? true : !target.isFavorite;
                if (target.isFavorite) {
                    favoriteService.setStorage(target);
                } else {
                    favoriteService.removeStorage(target.id);
                }

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

        $scope.checkedFun = function (target) {
            if (target.checked) {
                $scope.checkedCount++;
                variusCharacters.push(target)
            } else {
                $scope.checkedCount--;
                variusCharacters.splice(variusCharacters.indexOf(target.id), 1);
            };
        }

        $scope.checkedFavoritesAdd = function () {
            angular.forEach(variusCharacters, function (v, k) {
                v.isFavorite = v.isFavorite === undefined ? true : !v.isFavorite;
                favoriteService.setStorage(v);
            })
        }

        function getFavorite(id) {
            return favoriteService.getStorage(id) === undefined ? false : true;
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
            } else {
                $scope.allpag.push(
                    { id: 0, min: 0, max: 10 }
                );
            }

        }
    }
})();