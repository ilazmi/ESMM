$(document).ready(function () {
    $('#customerList').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.22/i18n/Turkish.json"
        },
        "initComplete": function (settings, json) {
            $(this).show();
        }
    });
    $('#addEditCustomer').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        $(this).find('.modal-title').text(button.data('title'));
        $(this).find('.modal-body').load(button.attr("href"), function (event) {
            $('input:radio[name="type"]').on('change', function () {
                $('#Name').prop('disabled', this.value == 2);
                $('#Surname').prop('disabled', this.value == 2);
                $('#CompanyTitle').prop('disabled', this.value == 1);
                $('label[for="TaxNumber"]').text(this.value == 1 ? "T.C. Kimlik No" : "Vergi No");
            });
            $('#City_Name').on('change', function () {
                $.ajax({
                    url: '/District/GetCityDistricts/' + $('#City_Name').val(),
                    cache: false,
                    type: "GET",
                    dataType: 'json',
                    success: function (response) {
                        $('#District_Name').empty().append($("<option disabled selected />").val("").text("-- Bir değer seçin --"));
                        $.each(response, function () {
                            $('#District_Name').append($("<option />").val(this.id).text(this.name))
                        });
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        let errorMessage = '';
                        try {
                            let response = jQuery.parseJSON(xhr.responseText);
                            errorMessage = response.message;
                        } catch (exc) {
                            if (xhr.responseText.length > 0) {
                                errorMessage = xhr.responseText;
                            } else {
                                errorMessage = thrownError
                            }
                        }
                        console.log(errorMessage);
                    }
                });
            });
        });
    });
});
