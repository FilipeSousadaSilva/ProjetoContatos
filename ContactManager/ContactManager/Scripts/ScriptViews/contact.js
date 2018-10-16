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
    
$('#saveContact').click(function ()
{
    var IdValidation = new RegExp(/^(\d)+$/g);
    //var IdValidation = new RegExp('^(?!\s*$).+');
    var NameValidation = new RegExp('^(?!\s*$).+');

    var Id = $('#Id').val();
    var Name = $('#Name').val();

    if (NameValidation.exec(Name) == null || IdValidation.exec(Id) == null)
    {
        $("#MessageForm").html("<b id='Temp'>Um ou mais campos não foram preenchidos corretamente!</b>").css("color", "red").fadeIn().fadeOut(7000);
    } else
    {
        $("#Temp").hide();
        $.post("/api/contact",
        $("#saveContactForm").serialize(),
        function (value)
        {
            $('#contacts').append('<li>' + value.Name + '</li>');
        },
        "json"
        );
        $("#MessageForm").html("<b id='Temp'>Contato cadastrado com sucesso!</b>").css("color", "green").fadeIn().fadeOut(5000);
    }
});