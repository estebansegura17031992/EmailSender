(function () {
	angular.module('EmailSender').factory('mail', mail);
	//mail.$inject = ['$resource'];
	function mail() {
		return {
			GetMails: function () {
				var result = null;
				$.ajax({
					type: "GET",
					url: "/Home/GetMails",
					contentType: "application/json; charset=utf-8",
					data: {},
					async: false,
					dataType: "json",
					success: function (data) {
						result = data;
					},
					error: function (errorData) {
						alert(errorData);
					}
				})

				return result;
			}
		}
	}
})();