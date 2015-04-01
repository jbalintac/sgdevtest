$(document).ready(function () {
    var isNumeric = function( obj ) {
        return !jQuery.isArray( obj ) && (obj - parseFloat( obj ) + 1) >= 0;
    }

    $("#add").click(function () {
        $('#sg-product tbody>tr:last').clone(true).insertAfter('#sg-product tbody>tr:last');
        return false;
    });

    $("#submit").click(function () {

        var orderItem = [];

        _.each($('.fetch'), function (f) {

            orderItem.push({
                ID: $(f).find(".product").val(),
                Count: $(f).find("input[name='quantity']").val()
            });
        });

        var orderItemClean = _.reject(orderItem, function (f) {
            return !isNumeric(f.Count); // or some complex logic
        });

        var obj = {

            CustomerID: $(".customer").val(),
            Products: orderItemClean
        }

        console.log(obj);

        $.ajax({
            url: '/Create/New',
            type: "POST",
            data: JSON.stringify(obj),
            contentType: 'application/json; charset=utf-8',
            success: function (data, textStatus) {
                if (data.Redirect) {
                    // data.redirect contains the string URL to redirect to
                    window.location = data.Redirect;
                }
            },
            error: function () {
                console.log('error :(');
            }
        });
    });
});