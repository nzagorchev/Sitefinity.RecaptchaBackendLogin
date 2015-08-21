<%@ Control Language="C#" %>
<%@ Register TagPrefix="sf" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>

<sf:ResourceLinks ID="resourceLinks" runat="server">
    <sf:ResourceFile Name="Styles/Login.css" />
</sf:ResourceLinks>

<%@ Import Namespace="Telerik.Sitefinity.Configuration" %>

<!-- Additional Error messages class -->
<style>
    .sfFailureFix {
        margin: 0 !important;
    }

        .sfFailureFix[style*="inline"] {
            display: block !important;
        }
</style>

<!-- Additional JavaScript -->
<script>
    // Recaptcha Onload script
    function recaptchaOnload() {
        grecaptcha = grecaptcha.render('grecaptcha', {
            'sitekey': '<%= Config.Get<RecaptchaBackendLogin.RecaptchaConfig>().RecaptchaSiteKey %>',//'< sitekey >',
            'theme': '<%= Config.Get<RecaptchaBackendLogin.RecaptchaConfig>().RecaptchaTheme %>',//'light',
            'type': '<%= Config.Get<RecaptchaBackendLogin.RecaptchaConfig>().RecaptchaType %>',//'image'
        });
    };

    (function ($) {
        $(document).ready(function () {
            // Fix inputs name to match the expected from the TokenService handler.
            // Relies on inputs ids.
            var elements = [];
            elements.push($('.sfLoginForm #wrap_name'));
            elements.push($('.sfLoginForm #wrap_password'));
            $.each(elements, function () {
                $(this).attr('name', $(this).attr('id'));
            });

            // Set error messages class
            var validators = [];
            var userError = $('#' + '<%= RequiredFieldValidatorUserName.ClientID%>');
            validators.push(userError);
            var passError = $('#' + '<%= RequiredFieldValidatorPassword.ClientID%>');
            validators.push(passError);

            $.each(validators, function () {
                $(this).addClass('sfFailure');
                $(this).addClass('sfFailureFix');
            });

        });
    }(jQuery));
</script>

<fieldset class="sfLoginForm">
    <asp:Panel ID="Panel1" CssClass="sfForm" runat="server" DefaultButton="hiddenSubmitButton">
        <div class="sfFormIn" id="LoginFormControl">
            <div class="sfLoginShadowTopRight"></div>
            <div class="sfLoginShadowBottomLeft"></div>
            <h2>
                <asp:Literal ID="LoginTitle" Text="<%$ Resources:Labels, LoginToManage %>" runat="server" />
            </h2>
            <sf:SitefinityLabel runat="server" ID="errorLabel" WrapperTagName="div" HideIfNoText="True" CssClass="sfFailure" />
            <ol>
                <li runat="server" id="ProvidersPanel">
                    <asp:Label ID="ProviderLabel" AssociatedControlID="ProvidersList" runat="server" Text="<%$ Resources:Labels, Provider %>" CssClass="sfTxtLbl" />
                    <select id="ProvidersList" runat="server" onchange="providersListChange();" />
                    <input id="sf_domain" name="sf_domain" type="hidden" />
                </li>
                <li>
                    <label for="wrap_name" class="sfTxtLbl">
                        <asp:Literal ID="Literal1" Text="<%$ Resources:Labels, Username %>" runat="server" />
                    </label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorUserName"
                        ControlToValidate="wrap_name"
                        Display="Dynamic"
                        ErrorMessage="<%$ Resources:RecaptchaResources, UsernameRequiredErrorMessage %>"
                        runat="server" />

                    <input runat="server" clientidmode="Static" type="text" id="wrap_name" name="wrap_name" class="sfTxt" />
                </li>
                <li>
                    <label for="wrap_password" class="sfTxtLbl">
                        <asp:Literal ID="Literal2" Text="<%$ Resources:Labels, Password %>" runat="server" />
                    </label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword"
                        ControlToValidate="wrap_password"
                        Display="Dynamic"
                        ErrorMessage="<%$ Resources:RecaptchaResources, PasswordRequiredErrorMessage %>"
                        runat="server" />

                    <input runat="server" clientidmode="Static" type="password" id="wrap_password" name="wrap_password" class="sfTxt" />
                </li>

                <li>
                    <!-- Recaptcha Element -->
                    <div id="grecaptcha" class="g-recaptcha"></div>
                    <br />
                </li>

                <li class="sfCheckBoxWrapper">
                    <input type="checkbox" id="sf_persistent" name="sf_persistent" <%= Config.Get<Telerik.Sitefinity.Security.Configuration.LoginConfig>().DefaultRememberMeLoginCheckBoxValue ? @"value=""true"" checked=""checked""" : "" %> />
                    <label for="sf_persistent">
                        <asp:Literal ID="Literal3" Text="<%$ Resources:Labels, RememberMe %>" runat="server" />
                    </label>
                </li>

                <li runat="server" id="StartupHintPanel" visible="false">
                    <a id="StartupHintLink" onclick="startupHintClick()" class="sfMoreDetails sfHelpLnk">
                        <asp:Literal ID="LoginDemoCredentialsQuestion" Text="<%$ Resources:Labels, LoginDemoCredentialsQuestion %>" runat="server" />
                    </a>

                    <div id="startupHint" class="sfNeutral sfCredentialInfo" style="display: none;">
                        <p>
                            <asp:Label ID="StartupHintBody" runat="server" Text="<%$ Resources:Labels, LoginDemoCredentialsHint %>" />
                        </p>
                        <ul>
                            <li>
                                <asp:Literal ID="Literal4" Text="<%$ Resources:Labels, UsernameLower %>" runat="server" />:
                                <sf:SitefinityLabel ID="DefaultUser" runat="server" WrapperTagName="strong" />
                            </li>
                            <li>
                                <asp:Literal ID="Literal5" Text="<%$ Resources:Labels, PasswordLower %>" runat="server" />:                                  
                                <sf:SitefinityLabel ID="DefaultPassword" runat="server" WrapperTagName="strong" />
                            </li>
                        </ul>
                    </div>
                </li>
            </ol>
            <div class="sfSubmitBtn sfMainFormBtns">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="sfLinkBtn sfSave">
                    <strong class="sfLinkBtnIn">
                        <asp:Literal ID="LoginButtonLiteral" runat="server" Text="<%$ Resources:Labels, LoginCaps %>" />
                    </strong>
                </asp:LinkButton>
            </div>
            <!-- do not remove this button. It is used for the default form submit (pressing enter) -->
            <div style="display: none;">
                <input type="hidden" id="isFormRequest" name="isFormRequest" value="true" />
                <asp:Button ID="hiddenSubmitButton" runat="server" />
            </div>
        </div>
    </asp:Panel>
</fieldset>

<!-- Recaptcha script -->
<!-- Option for language fallback using language code https://developers.google.com/recaptcha/docs/language -->
<script src='https://www.google.com/recaptcha/api.js?onload=recaptchaOnload&render=explicit<%= string.IsNullOrEmpty(Config.Get<RecaptchaBackendLogin.RecaptchaConfig>().RecaptchaLanguageCode) ? "": ("&hl=" + Config.Get<RecaptchaBackendLogin.RecaptchaConfig>().RecaptchaLanguageCode) %>' async defer></script>

<!-- Default StsLoginForm script logic -->
<script type="text/javascript">
    var providersList;
    var sf_domain;

    function pageLoad() {
        $("body").addClass("sfLogin sfNoSidebar");
        sf_domain = $get("sf_domain");
        providersList = $get("<%= ProvidersList.ClientID %>");
        if (providersList && sf_domain)
            sf_domain.value = getProvidersListValue();
    }

    function getProvidersListValue() {
        var index = providersList.selectedIndex;
        if (index > -1 && providersList.options.length > index) {
            return providersList.options[index].value;
        }
        return "";
    }

    function startupHintClick() {
        $("#startupHint").toggle();
    }

    function providersListChange() {
        sf_domain.value = getProvidersListValue();

        return true;
    }
</script>
