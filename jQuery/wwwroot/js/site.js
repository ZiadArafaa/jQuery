$(document).ready(function () {
    $(".modal-btn").click(function () {
        var btn = $(this);
        var myModal = $("#Modal");

        $.ajax({
            url: btn.data("url"),
            method: "GET",
            success: function (response) {
                $(".modal-body").html(response);
                $.validator.unobtrusive.parse(myModal)
            },
        });

        myModal.find("#ModalLabel").text(btn.data("title"));
        myModal.modal("show");
    });
});

function onModalSuccess() {
    $("#Modal").modal("hide");
    swal({
        title: "Good job!",
        text: "You clicked the button!",
        type: "success",
        confirmButtonClass: "btn-primary",
        confirmButtonText: "Ok",
        closeOnConfirm: false,
        closeOnCancel: false
    }, function (isConfirm) {
        if (isConfirm) {
            location.reload();
        }
    });
}

function onModalFailure() {
    swal("Bad Request", "Chech your values", "error");
}