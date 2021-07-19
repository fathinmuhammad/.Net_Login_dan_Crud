
jQuery(document).ready(function () {

	$(document).on('change', '#question_id', function () {
		var dID = $(this).val();

		if (dID != "") {
			var url = $("#getSubQuestionUrl").val();
			$.getJSON(url, { questionid: dID },
				function (data) {
					var select = $("#sub_question_id");
					select.empty();
					select.append($('<option/>', {
						value: "",
						text: ""
					}));
					$.each(data, function (index, itemData) {
						select.append($('<option/>', {
							value: itemData.sub_question_id,
							text: itemData.sub_question_desc
						}));
					});
				});
		}
		else {
			var select = $("#sub_question_id");
			select.empty();
			select.append($('<option/>', {
				value: "",
				text: ""
			}));
		}

	});

});