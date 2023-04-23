$(function () {
    var l = abp.localization.getResource("CommentManagement");
	
	var commentService = window.jS.abp.commentManagement.comments.comment;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "CommentManagement/Comments/CreateModal",
        scriptUrl: "/Pages/CommentManagement/Comments/createModal.js",
        modalClass: "commentCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "CommentManagement/Comments/EditModal",
        scriptUrl: "/Pages/CommentManagement/Comments/editModal.js",
        modalClass: "commentEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            entityType: $("#EntityTypeFilter").val(),
			entityId: $("#EntityIdFilter").val(),
			text: $("#TextFilter").val(),
			repliedCommentId: $("#RepliedCommentIdFilter").val()
        };
    };

    var dataTable = $("#CommentsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(commentService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('CommentManagement.Comments.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('CommentManagement.Comments.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    commentService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "entityType" },
			{ data: "entityId" },
			{ data: "text" },
			{ data: "repliedCommentId" }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewCommentButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        commentService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/comment-management/comments/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText }, 
                            { name: 'entityType', value: input.entityType }, 
                            { name: 'entityId', value: input.entityId }, 
                            { name: 'text', value: input.text }, 
                            { name: 'repliedCommentId', value: input.repliedCommentId }
                            ]);
                            
                    var downloadWindow = window.open(url, '_blank');
                    downloadWindow.focus();
            }
        )
    });

    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reload();
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reload();
    });
    
    
});
