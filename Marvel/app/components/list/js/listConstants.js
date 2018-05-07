angular.module('listmodule')
    .constant('list.constants', constants())


function constants() {
    return {
        REMOVE: 'Quitar de favoritos',
        ADD: 'Agregar a favoritos',
        CLOSE: 'Cerrar'
    }
}