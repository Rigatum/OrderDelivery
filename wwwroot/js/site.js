function OpenOrderDetailModal(orderId, orderNumber)
{
    $('#orderModal .modal-title').text(`Заказ #${orderNumber}`);

    $.ajax({
        url: `/Order/OrderDetails/${orderId}`,
        type: 'GET',
        success: function(html) {
            const modalBody = $(html).find('.modal-body').html();

            $('#orderModal .modal-body')[0].innerHTML = modalBody;

            $('#orderModal').modal('show');
        },
        error: function() {
            alert('Произошла ошибка');
        }
    });
}