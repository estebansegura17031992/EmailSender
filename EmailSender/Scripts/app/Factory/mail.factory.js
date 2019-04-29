(function () {
	angular.module('EmailSender').factory('MailService', mail);
	//mail.$inject = ['$resource'];
	function mail() {
        return {
            SendMail: function (EmailModel) {
                console.log(EmailModel)
                var result = false;
                $.ajax({
                    type: "POST",
                    url: "Home/SendEmail",
                    data: { email: EmailModel },
                    async: false,
                    dataType: "json",
                    success: function (data) {
                        result = data;
                    },
                    error: function (errorData) {
                        console.log(errorData)
                        alert(errorData);
                    }
                })

                return result;
            },
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