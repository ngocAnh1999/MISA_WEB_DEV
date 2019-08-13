$(document).ready(function () {
    var cus = new Cus();
    
});


class Cus extends Base {
    constructor() {
        super();
        this.InitEvents();
    }

    InitEvents() {
        $('.main-table tbody').on('click', 'tr', { "jsObject": this }, this.RowOnClick);
        $('.toolbar').on('click', 'button.add-new', this.openDialog);
        $('.toolbar').on('click', 'button.edit', this.openDialogEdit.bind(this));
        $('#dialog').on('click', 'button.save', this.AddNewCustomer.bind(this));
        $('#dialog').on('click', 'button.cancel', this.CloseDialog);
        $(document).on('click', 'td', { "jsObject": this }, this.TickRow);
        $('.toolbar').on('click', 'button.delete', this.ClickButtonDelete.bind(this));
    }


    /**
     * Hàm mở dialog cho sự kiện edit
     * Người tạo: Ngọc Ánh
     * Ngày tạo: 04/08/2019
     * @param {any} event
     */
    openDialogEdit() {

        var CustomerID = this.GetRowID();
        $("#dialog").dialog({
            title: "Sửa khách hàng",
            modal: true, // chặn các thao tác bên ngoài khi mở dialog
            height: 552,
            width: 723
        });
    }


    /**
     * Hàm thực hiện thêm dấu tick
     * Người tạo: Ngọc Ánh
     * Ngày tạo: 04/08/2019
     */
    TickRow(event) {
        
        var me = this;
        $(this).parent().addClass('check');
    }

    /**Hàm hiển thị khi click vào một hàng
     * Người tạo: Ngọc Ánh
     * Ngày tạo: 04/08/2019
     * */
    RowOnClick(event) {

        var me = event.data["jsObject"];
        $('button').removeAttr('disabled');
        var cls = $(this).hasClass('select');
        debugger
        if (cls) {
            $(this).removeClass('select');
            $(this).children('.check').addClass('uncheck');
            $(this).children().removeClass('check');
            
        }
        else {
            $(this).addClass('select');
            $(this).children('.uncheck').addClass('check');
            $(this).children().removeClass('uncheck');
        }
        
    }

    /**
     * Hàm thực hiện xóa dữ liệu
     * Người tạo: Ngọc Ánh
     * Ngày tạo: 04/08/2019
     * */
    ClickButtonDelete() {
        var me = this;
        var listCustomerID = [];
        var CustomerID = me.GetRowID();

        listCustomerID.push(CustomerID);
        debugger
        $.ajax({
            method: 'DELETE',
            url: '/customers',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(listCustomerID),
            success: function (res) {
                me.loadData();
            },
            error: function (res) {
                alert("Chức năng xóa đang bị lỗi! Vui lòng liên hệ MISA");
            }
        });
    }


    /**
     * Hàm đóng dialog
     * Người tạo: Ngọc Ánh
     * Ngày tạo: 04/08/2019
     * */
    CloseDialog() {
        $('#dialog').dialog('close');
    }

    /**
     * Hàm mở dialog thêm mới
     * Người tạo: Ngọc Ánh
     * Ngày tạo: 04/08/2019
     * */
    openDialog() {
        $("#dialog").dialog({
            title: "Thêm mới khách hàng",
            modal: true, // chặn các thao tác bên ngoài khi mở dialog
            height: 552,
            width: 723
        });
    }

    /**
     * Hàm thực hiện thêm mới khách hàng 
     * Người tạo; Ngọc Ánh
     * Ngày tạo: 04/08/2019
     * */

    AddNewCustomer() {
        var me = this;
        var listInput = $('#dialog [property]');
        var object = {};
        var CustomerID = me.GetRowID();
        $.each(listInput, function (index, item) {
            var propertyName = item.getAttribute('property');
            var value = $(this).val();
            object[propertyName] = value;
            
        });
        debugger 
        var x = $("div#dialog").data("uiDialog").options.title;
        if (x === "Thêm mới khách hàng") {
            $.ajax({
                method: 'POST',
                url: '/customers',
                async: false,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(object),

                success: function (res) {
                    if (res.Success) {
                        $('#dialog').dialog('close');
                        me.loadData();
                    }
                    else {
                        alert(res.Message);
                    }
                },
                error: function (res) {
                    alert("Can't update! The services is error. Please, contact with MISA to work.")
                }

            })
        }
        if (x === "Sửa khách hàng") {
                $.ajax({
                    method: 'PUT',
                    url: '/customers/{0}'.format(CustomerID),
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(object),
                    success: function (res) {
                        if (res.Success) {
                            $('#dialog').dialog('close');
                            me.loadData();
                        }
                        else {
                            alert(res.Message);
                        }
                    },
                    error: function (res) {
                        alert("Can't update! The services is error. Please, contact with MISA to work.")
                    }

                })
        }
        
        
    }


    GetRowID() {
        var rowid = $('.row-selected').data('recordID');
        return rowid;
    }

    /**
     * Hàm thực hiện load dữ liệu
     * Người tạo: Ngọc Ánh
     * Ngày tạo: 04/08/2019
     * */
    loadData() {
        super.loadData();
    }
    SetStatusButton() {
        super.SetStatusButton();
    }
    
}
