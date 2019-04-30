(function () {
    angular.module("EmailSender").controller("HistorialController", HistorialController);
    HistorialController.$inject = ["$scope", "MailService"];
    function HistorialController($scope, MailService) {
        $scope.mails = MailService.GetMails();

        $scope.filterHistory = function () {
            var searchString = $scope.filterHistoryMail;
            var searchBy = $scope.filterBy;
            if (searchString != "") {
                if (searchBy != undefined) {
                    $scope.mails = MailService.GetMailsByFilter(searchString, searchBy);
                } else {
                    alert("Seleccione una opcion (Correo, Asunto, Fecha)")
                }
            }
        }
    }
})();