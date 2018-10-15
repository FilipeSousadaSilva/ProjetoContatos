$(function()
    {
        $.getJSON('/api/contact', function(contactsJsonPayload)
        {
            $(contactsJsonPayload).each(function(i, item)
            {
                $('#contacts').append('<li>' + item.Name + '</li>');
            });
        });
    });
    
$('#saveContact').click(function () {
    $.post("/api/contact",
          $("#saveContactForm").serialize(),
          function (value) {
              $('#contacts').append('<li>' + value.Name + '</li>');
          },
          "json"
    );
});

$("#saveContactForm").validate({
    rules: {
        contactId: "required",
        contactName: "required",
    },
    messages: {
        contactId: "Campo obrigatório",
        contactName: "Campo obrigatório",
    }
});
