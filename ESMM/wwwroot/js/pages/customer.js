$(document).ready(function () {
    var modalTitle;
    var customerTable = $('#customerList').DataTable({
        "dom": "<'row mb-2 d-print-none'<'#customerListButtons.col-sm-12 col-md-6'B><'#customerListToolbar.col-sm-12 col-md-6'>>" +
            "<'row'<'col-sm-12 col-md-6'l><'col-sm-12 col-md-6'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
        buttons: [{
            text: '<span class="fa fa-plus" aria-hidden="true"></span> Ekle',
            className: 'btn btn-primary',
            action: function (e, dt, node, config) { }
        }, {
            text: '<span class="fa fa-pencil-alt" aria-hidden="true"></span> Düzenle',
            className: 'btn btn-success btn-edit',
            action: function (e, dt, node, config) { }
        }, {
            text: '<span class="fa fa-trash" aria-hidden="true"></span> Sil',
            className: 'btn btn-danger btn-delete',
            action: function (e, dt, node, config) { }
        }],
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.22/i18n/Turkish.json"
        },
        "initComplete": function (settings, json) {
            $(this).removeClass('d-none');
        }
    });
    $('#customerList tbody').on('click', 'tr', function () {
        if (!customerTable.data().count()) {
            return;
        }
        if ($(this).hasClass(dataTableSelectedRowClass)) {
            $(this).removeClass(dataTableSelectedRowClass);
            $('#customerListButtons')
                .find('.btn-edit')
                .attr('disabled', true)
                .end()
                .find('.btn-delete')
                .attr('disabled', true);
        } else {
            customerTable.$('tr.bg-lightblue').removeClass(dataTableSelectedRowClass);
            $(this).addClass(dataTableSelectedRowClass);
            $('#customerListButtons')
                .find('.btn-edit')
                .attr('disabled', false)
                .end()
                .find('.btn-delete')
                .attr('disabled', false);
        }
    });
    $('#addEditCustomer').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget);
        modalTitle = button.data('title');
        $(this).find('.modal-title').text(modalTitle);
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
    }).find('#cancelBtn').on('click', function (event) {
        toastr.warning(modalTitle + " işlemi iptal edildi!");
    }).end().find('#submitBtn').on('click', function (event) {
        
    });
});
