$(document).ready(function () {
    $("#RoleSelector").multiselect({
        includeSelectAllOption: true,
        onChange: function() {
            $("#Roles").val($("#RoleSelector").val());
        }
    });
    
     var accountDataSource = new kendo.data.DataSource({
        transport: {
            read: {
                url: "/Account/GetAccount",
                type: "post"
            },
            update: {
                url: "/Account/AddOrUpdateAccount",
                type: "post"
            },
            destroy: {
                url: "/Account/DeleteAccount",
                type: "post",
            },
            create: {
                url: "/Account/AddOrUpdateAccount",
                type: "post"
            },
            parameterMap: function (options, operation) {
                if (operation !== "read" && options.models) {
                    return {
                        models: kendo.stringify(options.models)
                    };
                } 
            }
        },
        batch: true,
        pageSize: 10,
        serverPaging: true,
        schema: {
            model: {
                id: "Id",
                fields: {
                    Id: { editable: false, nullable: false, defaultValue: 0 },
                    UserName: { type: "string" },
                    FirstName: { type: "string" },
                    LastName: { type: "string" },
                    Department: { type: "string" },
                    Roles: { type: "string" }
                }
            },
            total: "total",
            data: "data"
        }
    });
    
    $("#AccountGrid").kendoGrid({
        dataSource: accountDataSource,
        navigatable: true,
        pageable: true,
        groupable: {
            messages: {
                empty: "Kéo thả tên cột vào đây để xem theo nhóm."
            }
        },
        height: 500,
        toolbar: [{ name: "create", text: "Thêm" }, { name: "save", text: "Lưu" }, { name: "cancel", text: "Hủy" }],
        columns: [
            { field: "UserName", title: "Mã", width: 50 },
            { field: "FirstName", title: "Mô tả", width: 200 },
            { field: "LastName", title: "Người nhận" },
            { field: "Department", title: "SĐT nhận", width: 100 },
            { field: "Roles", title: "Người gửi", hidden: true },
            { command: [{ name: "destroy", title: "&nbsp;", width: 70, text: "Xóa" }] }
        ],
        editable: true
    });
});