var searchString = '';
var requestLink = '';
var key = $("#key").data("value");

function main() 
{
    $("#textbar").on('type', function () {
        if (!($("#sbar").val())) {
            console.log("Nothing entered.");
        }
        else {
            
            searchString = $("#sbar").val().replace(" ", "+");
            $("#sbar").val('');
            requestLink = "http://api.giphy.com/v1/gifs/search?q=" + searchString + "&api_key=" + key;

            $(".gifRow").html(null);

          

            $.ajax({
                type: 'POST',
                url: '/Home/Index/',
                data: { search: searchString },
                success: function () {
                    console.log("Yay");
                }
            });
        }

        
    })
}


$(document).ready(main);



