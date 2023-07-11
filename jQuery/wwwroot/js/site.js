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
    swal("Good job!", "You clicked the button!", "success");
}

function onModalFailure() {
    swal("Bad Request", "Chech your values", "error");
}