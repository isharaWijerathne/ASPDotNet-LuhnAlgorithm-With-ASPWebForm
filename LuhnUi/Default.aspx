<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LuhnUi._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <main>
        <div class="d-flex justify-content-center">
            <div class="row">

                <div class="col-12 mb-3">
                    <label for="" class="form-label">Card Number</label>
                    <input id="cardNumber" type="text" class="form-control"  aria-describedby="emailHelp"/>
                </div>

                    <div class="col-6 mb-3">
                        <label for="exampleInputPassword1" class="form-label">Expiry Date</label>
                        <input id="expiryDate" type="text" placeholder="MM/YY" class="form-control" />
                    </div>

                    <div class="col-6 mb-3">
                        <label for="exampleInputPassword1" class="form-label">Cvv</label>
                        <input id="cvv" type="number" class="form-control" />
                    </div>

                    <div class="col-12 mb-3 form-check">
                        <div id="responceMessage" class="form-text">We'll never share your email with anyone else.</div>
                        <button id="btnCheck" type="submit" class="btn btn-primary ">Process</button>
                    </div>

            </div>

        </div>
    </main>

        
    <script>


        $(document).ready(() => {

            //hideResponceMessage
            $("#responceMessage").hide();
           
            $("#btnCheck").click((e) => {
                e.preventDefault();
                var CardName = $("#cardNumber").val();
                var ExpiryDate = $("#expiryDate").val();
                var Cvv = $("#cvv").val();


                if (CardName === "" || ExpiryDate === "" || Cvv === "") {
                    //alert("Please fill out all fields.");
                    validationMsgShow("ValidationFail","danger")
                } else {

                    console.log("Card Number:", CardName);
                    console.log("Expiry Date:", ExpiryDate);
                    console.log("CVV:", Cvv);

                    $.ajax({
                        type: "POST",

                        url: "http://localhost:47019/v1/card-validator",
                       
                        data: JSON.stringify(
                            {
                                CardNumber: CardName,
                                ExpireDate: ExpiryDate,
                                CVV: Cvv
                            }
                        ),

                        contentType: "application/json",

             

                        success: function (data) {
                            console.log(data.message.cardProvider + " " + data.status + data)
                             
                             validationMsgShow("Valid " + data.message.cardProvider + " Card", "success")
                           
                        },

                        error: function (errMsg) {
                            console.log(errMsg.responseJSON.message)
                            validationMsgShow(errMsg.responseJSON.message, "danger")
                        }
                    });
                }

            })



            //Validation function
            const validationMsgShow = (message,type) => {

                $("#responceMessage").html(`<div class="alert alert-${type}" role="alert">
                                                  ${message}
                                                </div>
                                                `)
                $("#responceMessage").show()

                setTimeout(() => {
                    $("#responceMessage").hide()
                },3000)
            }
        });
        


    </script>

</asp:Content>
