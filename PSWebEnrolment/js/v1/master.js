
    const steps = [
    {
            title:
                "Application Guidance",
            description:
                "Welcome to the application process. Please read the guidance carefully before continuing.",
            url:
                "/webenrolment.aspx?page=~/webcontrols/v2.0/applicationguidance.ascx&OfferingID=179330",
            content: `
            <div class="info-box">
                <div class="info-icon">i</div>
                <div>
                    <h3>Important information</h3>
                    <p>
                        Make sure you have all the necessary information
                        and documents ready before you start.
                        You can save your progress and return at any time.
                    </p>
                </div>
            </div>
            `
      },
    {
        title: "Personal Details",
    description:
            "Please provide your personal details.",
        url:
            "/webenrolment.aspx?page=~/webcontrols/v2.0/personaldetails.ascx&OfferingID=179330",
    content: `
    <form id="personal-details-form" novalidate>
        <section class="form-section" aria-labelledby="personal-heading">
            <h2 id="personal-heading">Your Personal details</h2>
            <div class="form-grid">
                <div class="form-group"><label for="legal-first-name">Legal first name</label><input class="form-control" id="legal-first-name" name="legalFirstName" type="text" autocomplete="given-name"><label class="checkbox-row"><input id="different-first-name" type="checkbox"> <span>I am known by a different first name</span></label></div>
                <div class="form-group"><label for="legal-last-name">Legal last name</label><input class="form-control" id="legal-last-name" name="legalLastName" type="text" autocomplete="family-name"><label class="checkbox-row"><input id="different-last-name" type="checkbox"> <span>I am known by a different last name</span></label></div>
                <div class="form-group conditional-field" id="known-first-group" hidden><label for="known-first-name">Known as first name</label><input class="form-control" id="known-first-name" name="knownFirstName" type="text"></div>
                <div class="form-group conditional-field" id="known-last-group" hidden><label for="known-last-name">Known as last name</label><input class="form-control" id="known-last-name" name="knownLastName" type="text"></div>
                <div class="form-group"><label for="middle-names">Legal Middle name(s)</label><input class="form-control" id="middle-names" name="middleNames" type="text" autocomplete="additional-name"></div>
                <div class="form-group"><label for="date-of-birth">Date of birth</label><input class="form-control" id="date-of-birth" name="dateOfBirth" type="date"><p class="field-hint">Applicants must be at least 18 years old.</p></div>
                <div class="form-group"><label for="biological-sex">Biological sex</label><select class="form-control" id="biological-sex" name="biologicalSex"><option value="">Please select</option><option>Female</option><option>Male</option><option>Intersex</option><option>Prefer not to say</option></select></div>
                <div class="form-group"><label for="pronouns">Preferred pronouns</label><select class="form-control" id="pronouns" name="pronouns"><option value="">Please select</option><option>She / her</option><option>He / him</option><option>They / them</option><option>Other</option><option>Prefer not to say</option></select></div>
                <div class="form-group"><label for="ethnicity">Ethnicity</label><input class="form-control" id="ethnicity" name="ethnicity" type="text"></div>
                <div class="form-group"><label for="primary-language">Primary language</label><select class="form-control" id="primary-language" name="primaryLanguage"><option value="">Please select</option><option>English</option><option>Welsh</option><option>Polish</option><option>Arabic</option><option>Somali</option><option value="other">Other</option></select></div>
                <div class="form-group conditional-field full-width" id="other-language-group" hidden><label for="other-language">Please specify primary language</label><input class="form-control" id="other-language" name="otherLanguage" type="text"></div>
            </div>
        </section>
        <section class="form-section" aria-labelledby="education-heading">
            <h2 id="education-heading">Your Education</h2>
            <div class="form-grid">
                <div class="form-group"><label for="previous-school">Previous school</label><select class="form-control" id="previous-school" name="previousSchool"><option value="">Please select</option><option>Ashton Park School</option><option>Bedminster Down School</option><option>Bridge Learning Campus</option><option>City of Bristol College</option><option value="other">Other</option></select></div>
                <div class="form-group conditional-field" id="other-school-group" hidden><label for="other-school">Enter school name and town</label><input class="form-control" id="other-school" name="otherSchool" type="text"></div>
            </div>
        </section>
    </form>
    `
      },
    {
        title: "Contact Details",
    description:
            "Provide your current contact information.",
        url:
            "/webenrolment.aspx?page=~/webcontrols/v2.0/contactdetails.ascx&OfferingID=179330",
    content: `

    <form id="contact-details-form" novalidate>
        <section class="form-section">
            <h2>Contact Details</h2>
            <p class="section-help">Please provide your current contact details. Fields marked * are compulsory.</p>
            <div class="contact-grid">
                <div class="form-group">
                    <label for="uk-mobile">UK Mobile telephone <span class="required">*</span></label>
                    <input class="form-control" id="uk-mobile" type="tel" autocomplete="tel" required>
                        <label class="checkbox-row"><input id="overseas-check" type="checkbox"><span>My number is an overseas number</span></label>
                </div>
                <div class="form-group hidden" id="overseas-group">
                    <label for="overseas-mobile">Overseas Mobile number <span class="required">*</span></label>
                    <input class="form-control" id="overseas-mobile" type="tel" autocomplete="tel">
                </div>
                <div class="form-group">
                    <label for="contact-email">Your Email address <span class="required">*</span></label>
                    <input class="form-control" id="contact-email" type="email" autocomplete="email" required>
                </div>
                <div class="form-group">
                    <label for="landline">Home landline telephone</label>
                    <input class="form-control" id="landline" type="tel">
                </div>
                <div class="form-group">
                    <label for="confirm-email">Retype your Email <span class="required">*</span></label>
                    <input class="form-control" id="confirm-email" type="email" required>
                        <div class="field-error" id="email-match-error">The email addresses must match.</div>
                </div>
                <div class="form-group">
                    <label for="country">Which country do you live in <span class="required">*</span></label>
                    <select class="form-control" id="country" required>
                        <option value="">Please select</option>
                        <option value="UK">United Kingdom</option>
                        <option>Afghanistan</option><option>Australia</option><option>Bangladesh</option>
                        <option>Canada</option><option>China</option><option>France</option><option>Germany</option>
                        <option>India</option><option>Ireland</option><option>Italy</option><option>Nigeria</option>
                        <option>Pakistan</option><option>Poland</option><option>Portugal</option><option>Spain</option>
                        <option>United States</option><option value="Other">Other</option>
                    </select>
                </div>
            </div>
        </section>

        <section class="form-section hidden" id="uk-address-section">
            <h2>Your UK Address</h2>
            <p class="section-help">This section is displayed when United Kingdom is selected as your country of residence. Fields marked * are compulsory.</p>
            <div class="contact-grid">
                <div class="form-group full-width">
                    <span class="field-label">UK Post Code <span class="required">*</span></span>
                    <div class="postcode-row">
                        <input class="form-control" id="current-postcode" type="text" autocomplete="postal-code" aria-required="true">
                            <button class="btn btn-secondary lookup-btn" type="button" data-postcode="current-postcode" data-results="current-results">Lookup postcode</button>
                    </div>
                    <div class="address-results hidden" id="current-results"><label>Select an address</label><select class="form-control"><option>Select an address</option></select></div>
                </div>
                <div class="form-group full-width"><label>House number/name and street <span class="required">*</span></label><input class="form-control uk-required" type="text" autocomplete="address-line1"></div>
                <div class="form-group"><label>Address line 2</label><input class="form-control" type="text" autocomplete="address-line2"></div>
                <div class="form-group"><label>Town/City <span class="required">*</span></label><input class="form-control uk-required" type="text" autocomplete="address-level2"></div>
                <div class="form-group"><label>County <span class="required">*</span></label><input class="form-control uk-required" type="text" autocomplete="address-level1"></div>
                <div class="form-group full-width"><label class="checkbox-row"><input id="previous-check" type="checkbox" aria-controls="previous-address-section" aria-expanded="false"><span>I have lived at a different address in the last 2 years</span></label></div>
            </div>
        </section>

        <section class="form-section hidden" id="previous-address-section">
            <h2>Your Previous UK Address</h2>
            <div class="contact-grid">
                <div class="form-group full-width">
                    <span class="field-label">UK Post Code <span class="required">*</span></span>
                    <div class="postcode-row">
                        <input class="form-control previous-required" id="previous-postcode" type="text">
                            <button class="btn btn-secondary lookup-btn" type="button" data-postcode="previous-postcode" data-results="previous-results">Lookup postcode</button>
                    </div>
                    <div class="address-results hidden" id="previous-results"><label>Select an address</label><select class="form-control"><option>Select an address</option></select></div>
                </div>
                <div class="form-group full-width"><label>House number/name and street <span class="required">*</span></label><input class="form-control previous-required" type="text"></div>
                <div class="form-group"><label>Address line 2</label><input class="form-control" type="text"></div>
                <div class="form-group"><label>Town/City <span class="required">*</span></label><input class="form-control previous-required" type="text"></div>
                <div class="form-group"><label>County <span class="required">*</span></label><input class="form-control previous-required" type="text"></div>
            </div>
        </section>
    </form>
    `
      },
    {
        title: "Parent/Carer Contact Details",
    description:
            "Provide parent or carer contact details where applicable.",
        url:
            "/webenrolment.aspx?page=~/webcontrols/v2.0/parentcarercontactdetails.ascx&OfferingID=179330",
    content: `

    <form id="parent-carer-form" novalidate>
        <section class="form-section">
            <h2>Your Parent/Carer Details</h2>
            <p class="section-help">Please provide details for your parent or carer. Fields marked * are compulsory.</p>

            <div class="contact-grid">
                <div class="form-group">
                    <label for="pc-first-name">Parent/Carer first name <span class="required">*</span></label>
                    <input class="form-control" id="pc-first-name" name="parentCarerFirstName" type="text" autocomplete="given-name" required>
                </div>

                <div class="form-group">
                    <label for="pc-last-name">Parent/Carer last name <span class="required">*</span></label>
                    <input class="form-control" id="pc-last-name" name="parentCarerLastName" type="text" autocomplete="family-name" required>
                </div>

                <div class="form-group">
                    <label for="pc-same-address">Does this Person live at the same address as you? <span class="required">*</span></label>
                    <select class="form-control" id="pc-same-address" name="parentCarerSameAddress" required>
                        <option value="">Please select</option>
                        <option value="yes">Yes</option>
                        <option value="no">No</option>
                    </select>
                </div>

                <div class="form-group">
                    <label for="pc-relationship">Relationship to you</label>
                    <select class="form-control" id="pc-relationship" name="parentCarerRelationship">
                        <option value="">Please select</option>
                        <option>Mother</option>
                        <option>Father</option>
                        <option>Step-mother</option>
                        <option>Step-father</option>
                        <option>Grandparent</option>
                        <option>Foster carer</option>
                        <option>Legal guardian</option>
                        <option>Other relative</option>
                        <option>Other carer</option>
                    </select>
                </div>
            </div>
        </section>

        <section class="form-section">
            <h2>Your Parent/Carer's Contact Details</h2>
            <p class="section-help">Please provide the best contact details for your parent or carer.</p>

            <div class="contact-grid">
                <div class="form-group">
                    <label for="pc-uk-mobile">Parent/Carer UK Mobile telephone</label>
                    <input class="form-control" id="pc-uk-mobile" name="parentCarerUkMobile" type="tel" autocomplete="tel">
                        <label class="checkbox-row" for="pc-overseas-check">
                            <input id="pc-overseas-check" name="parentCarerOverseasNumber" type="checkbox" aria-controls="pc-overseas-group" aria-expanded="false">
                                <span>My Parent/Carer has an overseas number</span>
                        </label>
                </div>

                <div class="form-group">
                    <label for="pc-landline">Parent/Carer landline telephone</label>
                    <input class="form-control" id="pc-landline" name="parentCarerLandline" type="tel">
                </div>

                <div class="form-group hidden" id="pc-overseas-group">
                    <label for="pc-overseas-mobile">Parent/Carer Overseas Mobile telephone</label>
                    <input class="form-control" id="pc-overseas-mobile" name="parentCarerOverseasMobile" type="tel">
                </div>

                <div class="form-group">
                    <label for="pc-email">Parent/Carer Email address</label>
                    <input class="form-control" id="pc-email" name="parentCarerEmail" type="email" autocomplete="email">
                        <div class="field-error" id="pc-email-error">Please enter a valid email address.</div>
                </div>

                <div class="form-group">
                    <label for="pc-email-confirm">Retype Email</label>
                    <input class="form-control" id="pc-email-confirm" name="parentCarerEmailConfirm" type="email" autocomplete="email">
                        <div class="field-error" id="pc-email-match-error">The email addresses must match.</div>
                </div>

                <div class="form-group full-width hidden" id="pc-uk-question">
                    <span class="field-label">Does your parent/Carer live in the UK? <span class="required">*</span></span>
                    <div class="radio-group" role="radiogroup" aria-label="Does your parent or carer live in the UK?">
                        <label class="radio-option">
                            <input type="radio" name="pcLivesUk" value="yes">
                                <span>Yes</span>
                        </label>
                        <label class="radio-option">
                            <input type="radio" name="pcLivesUk" value="no">
                                <span>No</span>
                        </label>
                    </div>
                </div>
            </div>
        </section>

        <section class="form-section hidden" id="pc-address-section">
            <h2>Your Parent/Carer's Address</h2>
            <p class="section-help">Please provide your parent/carer's address. Fields marked * are compulsory.</p>

            <div class="contact-grid">
                <div class="form-group full-width">
                    <span class="field-label">UK Post Code <span class="required">*</span></span>
                    <div class="postcode-row">
                        <input class="form-control pc-address-required" id="pc-postcode" name="parentCarerPostcode" type="text" autocomplete="postal-code">
                            <button class="btn btn-secondary lookup-btn" type="button" id="pc-postcode-lookup">Lookup postcode</button>
                    </div>

                    <div class="address-results hidden" id="pc-address-results">
                        <label for="pc-address-select">Select an address</label>
                        <select class="form-control" id="pc-address-select">
                            <option value="">Select an address</option>
                        </select>
                    </div>
                </div>

                <div class="form-group full-width">
                    <label for="pc-street">House number/name and street <span class="required">*</span></label>
                    <input class="form-control pc-address-required" id="pc-street" name="parentCarerStreet" type="text" autocomplete="address-line1">
                </div>

                <div class="form-group">
                    <label for="pc-address2">Address line 2</label>
                    <input class="form-control" id="pc-address2" name="parentCarerAddress2" type="text" autocomplete="address-line2">
                </div>

                <div class="form-group">
                    <label for="pc-town">Town/City <span class="required">*</span></label>
                    <input class="form-control pc-address-required" id="pc-town" name="parentCarerTown" type="text" autocomplete="address-level2">
                </div>

                <div class="form-group">
                    <label for="pc-county">County <span class="required">*</span></label>
                    <input class="form-control pc-address-required" id="pc-county" name="parentCarerCounty" type="text" autocomplete="address-level1">
                </div>
            </div>
        </section>
    </form>
    `
      },
    {
        title: "Residency Status",
    description:
            "Tell us about your residency status.",
        url:
            "/webenrolment.aspx?page=~/webcontrols/v2.0/residencystatus.ascx&OfferingID=179330",
    content: `

    <form id="residency-form" novalidate>
        <section class="form-section">
            <h2>Your Residency Status</h2>
            <p class="section-help">Please answer the following questions about your UK residency.</p>

            <div class="contact-grid">
                <div class="form-group">
                    <span class="field-label">Are you currently living in the UK?</span>
                    <div class="radio-group" role="radiogroup" aria-label="Are you currently living in the UK?">
                        <label class="radio-option"><input type="radio" name="currentlyUk" value="yes"><span>Yes</span></label>
                        <label class="radio-option"><input type="radio" name="currentlyUk" value="no"><span>No</span></label>
                    </div>
                </div>

                <div class="form-group">
                    <span class="field-label">Do you have a UK Passport?</span>
                    <div class="radio-group" role="radiogroup" aria-label="Do you have a UK Passport?">
                        <label class="radio-option"><input type="radio" name="ukPassport" value="yes"><span>Yes</span></label>
                        <label class="radio-option"><input type="radio" name="ukPassport" value="no"><span>No</span></label>
                    </div>
                </div>

                <div class="form-group">
                    <span class="field-label">Have you always lived in the UK?</span>
                    <div class="radio-group" role="radiogroup" aria-label="Have you always lived in the UK?">
                        <label class="radio-option"><input type="radio" name="alwaysUk" value="yes"><span>Yes</span></label>
                        <label class="radio-option"><input type="radio" name="alwaysUk" value="no"><span>No</span></label>
                    </div>
                </div>

                <div class="form-group hidden" id="birth-country-group">
                    <label for="birth-country">Country of birth</label>
                    <select class="form-control" id="birth-country" name="birthCountry">
                        <option value="">Please select</option>
                        <option>United Kingdom</option><option>Afghanistan</option><option>Australia</option>
                        <option>Bangladesh</option><option>Canada</option><option>China</option><option>France</option>
                        <option>Germany</option><option>India</option><option>Ireland</option><option>Italy</option>
                        <option>Nigeria</option><option>Pakistan</option><option>Poland</option><option>Portugal</option>
                        <option>Spain</option><option>United States</option><option>Other</option>
                    </select>
                </div>

                <div class="form-group hidden" id="uk-entry-group">
                    <label for="uk-entry-date">What date did you enter the UK?</label>
                    <input class="form-control" id="uk-entry-date" name="ukEntryDate" type="date">
                        <p class="date-format">Select a previous date.</p>
                </div>

                <div class="form-group">
                    <label for="three-years-uk">Have you lived in the UK for the last 3 years?</label>
                    <select class="form-control" id="three-years-uk" name="threeYearsUk">
                        <option value="">Please select</option>
                        <option value="yes">Yes</option>
                        <option value="no">No</option>
                    </select>
                </div>
            </div>
        </section>

        <section class="form-section">
            <h2>Visa and Immigration Details</h2>

            <div class="advice-box">
                <strong>Important information:</strong>
                If you have entered the UK from overseas, please complete further details in the section below.
                If you are not from overseas, please indicate "Not applicable" on the questions below.
            </div>

            <div class="contact-grid">
                <div class="form-group full-width">
                    <span class="field-label">Do you have a Visa?</span>
                    <div class="radio-group" role="radiogroup" aria-label="Do you have a Visa?">
                        <label class="radio-option"><input type="radio" name="hasVisa" value="yes"><span>Yes</span></label>
                        <label class="radio-option"><input type="radio" name="hasVisa" value="no"><span>No</span></label>
                        <label class="radio-option"><input type="radio" name="hasVisa" value="na"><span>Not applicable</span></label>
                    </div>
                </div>

                <div class="form-group" id="visa-type-group">
                    <label for="visa-type">What type of Visa <span class="required">*</span></label>
                    <select class="form-control visa-required" id="visa-type" name="visaType">
                        <option value="">Please select</option>
                        <option>Student visa</option>
                        <option>Skilled Worker visa</option>
                        <option>Health and Care Worker visa</option>
                        <option>Family visa</option>
                        <option>Graduate visa</option>
                        <option>Global Talent visa</option>
                        <option>British National (Overseas) visa</option>
                        <option>Ukraine scheme visa</option>
                        <option>Other</option>
                    </select>
                </div>

                <div class="form-group" id="visa-number-group">
                    <label for="visa-number">Visa Number <span class="required">*</span></label>
                    <input class="form-control visa-required" id="visa-number" name="visaNumber" type="text">
                </div>

                <div class="form-group" id="visa-start-group">
                    <label for="visa-start">Visa start <span class="required">*</span></label>
                    <input class="form-control visa-required" id="visa-start" name="visaStart" type="date">
                        <p class="date-format">Display format: dd-MMM-yyyy, for example 18-Sep-2026.</p>
                </div>

                <div class="form-group full-width">
                    <span class="field-label">Do you have an eVisa share code?</span>
                    <div class="radio-group" role="radiogroup" aria-label="Do you have an eVisa share code?">
                        <label class="radio-option"><input type="radio" name="evisaCode" value="yes"><span>Yes</span></label>
                        <label class="radio-option"><input type="radio" name="evisaCode" value="no"><span>No</span></label>
                        <label class="radio-option"><input type="radio" name="evisaCode" value="na"><span>Not applicable</span></label>
                    </div>
                </div>

                <div class="form-group hidden" id="share-code-group">
                    <label for="share-code">Share code <span class="required">*</span></label>
                    <input class="form-control" id="share-code" name="shareCode" type="text">
                </div>
            </div>
        </section>
    </form>
    `
      },
    {
        title: "Your Qualifications",
    description:
            "Provide details of your qualifications.",
        url:
            "/webenrolment.aspx?page=~/webcontrols/v2.0/yourqualifications.ascx&OfferingID=179330",
    content: `

    <form id="qualifications-form" novalidate>
        <section class="form-section">
            <div class="section-heading-row">
                <div>
                    <h2>Your Qualifications</h2>
                    <p class="section-help">Add each qualification or subject separately.</p>
                </div>
                <button class="btn btn-primary" id="add-qualification" type="button">+ Add Qualification</button>
            </div>

            <div class="advice-box">
                <strong>Qualification guidance:</strong>
                Please provide details of all relevant qualifications. Where your final result is known, enter your achieved grade.
                If you are awaiting your final result, enter your predicted grade. Please enter only one qualification or subject per entry.
                You can add further qualifications by selecting the "Add Qualification" button.
            </div>

            <div class="qualification-editor" id="qualification-editor">
                <div class="contact-grid">
                    <div class="form-group">
                        <label for="qualification-subject">Subject <span class="required">*</span></label>
                        <select class="form-control" id="qualification-subject" required>
                            <option value="">Please select</option>
                            <option>Art and Design</option><option>Biology</option><option>Business Studies</option>
                            <option>Chemistry</option><option>Computer Science</option><option>Design and Technology</option>
                            <option>Drama</option><option>Economics</option><option>English Language</option>
                            <option>English Literature</option><option>Geography</option><option>History</option>
                            <option>Information Technology</option><option>Mathematics</option><option>Media Studies</option>
                            <option>Modern Foreign Languages</option><option>Music</option><option>Physical Education</option>
                            <option>Physics</option><option>Psychology</option><option>Religious Studies</option>
                            <option>Science</option><option>Sociology</option><option>Other</option>
                        </select>
                    </div>

                    <div class="form-group">
                        <label for="qualification-type">Qualification <span class="required">*</span></label>
                        <select class="form-control" id="qualification-type" required>
                            <option value="">Please select</option>
                            <option>GCSE</option><option>GCSE (Short Course)</option><option>IGCSE</option>
                            <option>A Level</option><option>AS Level</option><option>BTEC Level 1</option>
                            <option>BTEC Level 2</option><option>BTEC Level 3</option><option>City &amp; Guilds Level 1</option>
                            <option>City &amp; Guilds Level 2</option><option>City &amp; Guilds Level 3</option>
                            <option>Functional Skills Level 1</option><option>Functional Skills Level 2</option>
                            <option>NVQ Level 1</option><option>NVQ Level 2</option><option>NVQ Level 3</option>
                            <option>T Level</option><option>Access to HE Diploma</option><option>Other</option>
                        </select>
                    </div>

                    <div class="form-group">
                        <label for="qualification-date">Date Obtained <span class="required">*</span></label>
                        <input class="form-control" id="qualification-date" type="date" required>
                            <p class="date-format">Display format: dd-MMM-yyyy, for example 18-Sep-2026.</p>
                    </div>

                    <div class="form-group">
                        <label for="qualification-result">Predicted/Actual Result <span class="required">*</span></label>
                        <select class="form-control" id="qualification-result" required>
                            <option value="">Please select</option>
                            <option>9</option><option>8</option><option>7</option><option>6</option><option>5</option>
                            <option>4</option><option>3</option><option>2</option><option>1</option>
                            <option>A*</option><option>A</option><option>B</option><option>C</option><option>D</option><option>E</option>
                            <option>Distinction*</option><option>Distinction</option><option>Merit</option><option>Pass</option>
                            <option>Awaiting result</option><option>Other</option>
                        </select>
                    </div>

                    <div class="form-group full-width qualification-actions">
                        <button class="btn btn-primary" id="save-qualification" type="button">Save Qualification</button>
                    </div>
                </div>
            </div>
        </section>

        <section class="form-section">
            <h2>Qualifications Added</h2>
            <p class="section-help">Qualifications you save will appear below. You can remove an entry using its Delete button.</p>

            <div class="qualification-table-wrap">
                <table class="qualification-table" aria-label="Qualifications added">
                    <thead>
                        <tr>
                            <th scope="col">Subject</th>
                            <th scope="col">Qualification</th>
                            <th scope="col">Date Obtained</th>
                            <th scope="col">Result</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody id="qualifications-body">
                        <tr class="empty-row" id="qualifications-empty">
                            <td colspan="5">No qualifications have been added yet.</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <p class="qualification-count" id="qualification-count">0 qualifications added</p>
        </section>
    </form>
    `
      },
    {
        title: "Personal Statement",
    description:
            "Tell us about yourself and your application.",
        url:
            "/webenrolment.aspx?page=~/webcontrols/v2.0/personalstatement.ascx&OfferingID=179330",
    content: `

    <form id="personal-statement-form" novalidate>
        <section class="form-section">
            <h2>Personal Statement</h2>

            <div class="advice-box">
                <strong>Personal statement guidance:</strong>
                Please provide a personal statement explaining why you would like to study at City of Bristol College.
                Your statement should cover all the courses you have selected as your study choices.
            </div>

            <div class="statement-wrap">
                <label class="field-label" for="personal-statement">
                    Your personal statement <span class="required">*</span>
                </label>
                <textarea
                    class="statement-textarea"
                    id="personal-statement"
                    name="personalStatement"
                    minlength="100"
                    maxlength="500"
                    required
                    aria-describedby="statement-requirement statement-count"
                    placeholder="Enter your personal statement here..."></textarea>

                <div class="statement-meta">
                    <span id="statement-requirement">Minimum 100 characters, maximum 500 characters.</span>
                    <span id="statement-count" aria-live="polite">0 / 500 characters</span>
                </div>
            </div>
        </section>
    </form>
    `
      },
    {
        title: "Learning Difficulty & Diabetes",
    description:
            "Provide relevant learning difficulty and diabetes information.",
        url:
            "/webenrolment.aspx?page=~/webcontrols/v2.0/learningdifficultyanddisability.ascx&OfferingID=179330",
    content: `

    <form id="learning-difficulty-form" novalidate>
        <section class="form-section">
            <h2>Learning Difficulty, Disability or Health Condition</h2>
            <p class="section-help">Please answer the following questions about any learning difficulty, disability, health condition or support needs.</p>

            <div class="contact-grid">
                <div class="form-group">
                    <span class="field-label">Do you have a learning difficulty, disability or health condition?</span>
                    <div class="radio-group" role="radiogroup" aria-label="Do you have a learning difficulty, disability or health condition?">
                        <label class="radio-option"><input type="radio" name="hasLearningDifficulty" value="yes"><span>Yes</span></label>
                        <label class="radio-option"><input type="radio" name="hasLearningDifficulty" value="no"><span>No</span></label>
                    </div>
                </div>

                <div class="form-group">
                    <label for="previous-support">Did you receive additional support from your previous school?</label>
                    <select class="form-control" id="previous-support" name="previousSupport">
                        <option value="">Please select</option>
                        <option value="yes">Yes</option>
                        <option value="no">No</option>
                    </select>
                </div>

                <div class="form-group">
                    <span class="field-label">Do you have an Education Health Care Plan?</span>
                    <div class="radio-group" role="radiogroup" aria-label="Do you have an Education Health Care Plan?">
                        <label class="radio-option"><input type="radio" name="ehcp" value="yes"><span>Yes</span></label>
                        <label class="radio-option"><input type="radio" name="ehcp" value="no"><span>No</span></label>
                    </div>
                </div>

                <div class="form-group">
                    <span class="field-label">Can we request data regarding your support needs from your school?</span>
                    <div class="radio-group" role="radiogroup" aria-label="Can we request data regarding your support needs from your school?">
                        <label class="radio-option"><input type="radio" name="requestSupportData" value="yes"><span>Yes</span></label>
                        <label class="radio-option"><input type="radio" name="requestSupportData" value="no"><span>No</span></label>
                    </div>
                </div>

                <div class="form-group full-width">
                    <label for="evacuation-assistance">In the event of an emergency, would you require assistance to evacuate the building?</label>
                    <select class="form-control" id="evacuation-assistance" name="evacuationAssistance">
                        <option value="">Please select</option>
                        <option value="yes">Yes</option>
                        <option value="no">No</option>
                    </select>
                </div>
            </div>
        </section>

        <section class="form-section">
            <h2>Your Learning Difficulty, Disability or Health Condition</h2>

            <div class="advice-box">
                <strong>Please select all that apply:</strong>
                Please tick all learning difficulty, disability or health problem or condition that apply to you.
            </div>

            <div class="condition-grid" role="group" aria-label="Learning difficulties, disabilities or health conditions">
                <label class="condition-option">
                    <input type="checkbox" name="conditions" value="Vision impairment">
                        <span>Vision impairment</span>
                </label>

                <label class="condition-option">
                    <input type="checkbox" name="conditions" value="Autism spectrum disorder">
                        <span>Autism spectrum disorder</span>
                </label>

                <label class="condition-option">
                    <input type="checkbox" name="conditions" value="Hearing impairment">
                        <span>Hearing impairment</span>
                </label>

                <label class="condition-option">
                    <input type="checkbox" name="conditions" value="Temporary disability after illness or accident">
                        <span>Temporary disability after illness or accident</span>
                </label>
            </div>

            <div class="contact-grid" style="margin-top:24px;">
                <div class="form-group full-width">
                    <label for="main-condition">Please select your main learning difficulty, disability or health condition</label>
                    <select class="form-control" id="main-condition" name="mainCondition">
                        <option value="">Please select</option>
                        <option value="Vision impairment">Vision impairment</option>
                        <option value="Autism spectrum disorder">Autism spectrum disorder</option>
                        <option value="Hearing impairment">Hearing impairment</option>
                        <option value="Temporary disability after illness or accident">Temporary disability after illness or accident</option>
                    </select>
                    <p class="form-hint">Select the condition you consider to be your main learning difficulty, disability or health condition.</p>
                </div>
            </div>
        </section>
    </form>
    `
      },
    {
        title: "Additional Details",
    description:
            "Provide any additional information.",
        url:
            "/webenrolment.aspx?page=~/webcontrols/v2.0/additionaldetails.ascx&OfferingID=179330",
    content: `

    <form id="additional-details-form" novalidate>
        <section class="form-section">
            <h2>Care Experienced</h2>
            <p class="section-help">
                Please answer the following questions about any care experience or caring responsibilities.
            </p>

            <div class="contact-grid">
                <div class="form-group">
                    <label for="child-in-care">Are you a child in care?</label>
                    <select class="form-control" id="child-in-care" name="childInCare">
                        <option value="">Please select</option>
                        <option value="yes">Yes</option>
                        <option value="no">No</option>
                    </select>
                </div>

                <div class="form-group">
                    <label for="caring-responsibilities">
                        Do you have caring responsibilities for a member of your family?
                    </label>
                    <select class="form-control" id="caring-responsibilities" name="caringResponsibilities">
                        <option value="">Please select</option>
                        <option value="yes">Yes</option>
                        <option value="no">No</option>
                    </select>
                </div>

                <div class="form-group">
                    <label for="care-leaver">
                        Are you a care leaver (have you recently left being in care)?
                    </label>
                    <select class="form-control" id="care-leaver" name="careLeaver">
                        <option value="">Please select</option>
                        <option value="yes">Yes</option>
                        <option value="no">No</option>
                    </select>
                </div>

                <div class="form-group">
                    <label for="social-care-involvement">Do you have Social care involvement?</label>
                    <select class="form-control" id="social-care-involvement" name="socialCareInvolvement">
                        <option value="">Please select</option>
                        <option value="yes">Yes</option>
                        <option value="no">No</option>
                    </select>
                </div>
            </div>
        </section>
    </form>
    `
      },
    {
        title: "Previous Convictions",
    description:
            "Provide information about previous convictions.",
        url:
            "/webenrolment.aspx?page=~/webcontrols/v2.0/previousconvictions.ascx&OfferingID=179330",
    content: `

    <form id="previous-convictions-form" novalidate>
        <section class="form-section">
            <h2>Previous Convictions</h2>
            <p class="section-help">
                Please answer the following question about any unspent criminal convictions, outstanding court proceedings or offender register status.
            </p>

            <div class="contact-grid">
                <div class="form-group full-width">
                    <label for="previous-convictions">
                        Do you have any unspent criminal convictions, outstanding court proceedings, or are you on any offenders register?
                    </label>
                    <select class="form-control" id="previous-convictions" name="previousConvictions">
                        <option value="">Please select</option>
                        <option value="yes">Yes</option>
                        <option value="no">No</option>
                    </select>
                </div>
            </div>

            <div class="advice-box" style="margin-top:22px;">
                <strong>Important information:</strong>
                If you declare that you have a conviction, you will be contacted for further information.
                This information will help us assess any potential risks to yourself or others at college.
                The college has a duty of care to all of its staff and students to ensure that any risk to their safety is minimised.
                The college reserves the right not to enrol anyone who may pose a threat or danger to the safety of its staff and students.
                Having a criminal record will not necessarily prevent you from studying at the college.
                This is dependent on the nature of the course and the circumstances of the offence.
                If you do not disclose a conviction, this can result in disciplinary action or your enrolment being cancelled.
            </div>
        </section>
    </form>
    `
      },
    {
        title: "Privacy Notices",
    description:
            "Review the privacy notices.",
        url:
            "/webenrolment.aspx?page=~/webcontrols/v2.0/privacynotices.ascx&OfferingID=179330",
    content: `

    <section class="form-section">
        <h2>Privacy Notices</h2>
        <p class="section-help">Please read the following information about how your personal information may be used and shared.</p>
        <div class="privacy-notice">
            <article class="privacy-block">
                <h3>Learning Record Service (LRS) - Ability to Share</h3>
                <p>The information you supply is used by the LRS. The LRS issues Unique Learner Numbers (ULN) and creates Personal Learning records across England, Wales &amp; Northern Ireland, and is operated by the Department for Education (DfE) in England. For more information about how your information is processed, and to access your Personal Learning Record, please refer to: <a href="https://www.gov.uk/government/publications/lrs-privacy-notices" target="_blank" rel="noopener noreferrer">gov.uk/government/publications/lrs-privacy-notices</a>.</p>
            </article>

            <article class="privacy-block">
                <h3>Department for Education (DfE)</h3>
                <p>This privacy notice is issued on behalf of the Secretary of State for the Department of Education (DfE) to inform learners about the Individualised Learner Record (ILR) and how their personal information is used in the ILR. Your personal information is used by the DfE to exercise our functions under article 6(1)(e) of the UK GDPR and to meet our statutory responsibilities, including under the Apprenticeships, Skills, Children and Learning Act 2009. Our lawful basis for using your special category personal data is covered under Substantial Public Interest based in law (Article 9(2)(g)) of UK GDPR legislation. This processing is under Section 54 of the Further and Higher Education Act (1992).</p>
                <p>The ILR collects data about learners and learning undertaken. Publicly funded colleges, training organisations, local authorities, and employers (FE providers) must collect and return the data each year under the terms of a funding agreement, contract or grant agreement. It helps ensure that public money is being spent in line with government targets. It is also used for education, training, employment, and well-being purposes, including research.</p>
                <p>We retain your ILR learner data for 20 years for operational purposes (e.g. to fund your learning and to publish official statistics). Your personal data is then retained in our research databases until you are aged 80 years so that it can be used for long-term research purposes.</p>
                <p>For more information about the ILR and the data collected, please see the ILR specification at <a href="https://www.gov.uk/government/collections/individualised-learner-record-ilr" target="_blank" rel="noopener noreferrer">gov.uk/government/collections/individualised-learner-record-ilr</a>. ILR data is shared with third parties where it complies with DfE data sharing procedures and where the law allows it. The DfE and the English European Social Fund (ESF) Managing Authority (or agents acting on their behalf) may contact learners to carry out research and evaluation to inform the effectiveness of training.</p>
                <p>For more information about how your personal data is used and your individual rights, please see the <a href="https://www.gov.uk/government/organisations/department-for-education/about/personal-information-charter" target="_blank" rel="noopener noreferrer">DfE Personal Information Charter</a> and the <a href="https://www.gov.uk/government/publications/privacy-notice-for-key-stage-5-and-adult-education" target="_blank" rel="noopener noreferrer">DfE Privacy Notice</a>.</p>
                <p>If you would like to get in touch with us or request a copy of the personal information DfE holds about you, you can contact the DfE in the following ways:</p>
                <ol class="privacy-contact-list">
                    <li>Using the <a href="https://form.education.gov.uk/service/Contact_the_Department_for_Education" target="_blank" rel="noopener noreferrer">DfE online contact form</a>.</li>
                    <li>By telephoning the DfE Helpline on 0370 000 2288.</li>
                    <li>In writing to: Data Protection Officer, Department for Education, 4th Floor, 2 St Paul's Place, 125 Norfolk Street, Sheffield, S1 2FJ.</li>
                </ol>
                <p>If you are unhappy with how we have used your personal data, you can complain to the Information Commissioner’s Office (ICO) at: Wycliffe House, Water Lane, Wilmslow, Cheshire, SK9 5AF. You can also call their helpline on 0303 123 1113 or visit <a href="https://ico.org.uk/" target="_blank" rel="noopener noreferrer">www.ico.org.uk</a>.</p>
            </article>

            <article class="privacy-block">
                <h3>City of Bristol College</h3>
                <p>Generally, the information is processed as part of our public interest task of providing education to you. For further information about use of and access to your personal data, details of organisations with whom we regularly share data, information about how long we retain your data, and how to change your consent to being contacted, please visit: <a href="https://www.cityofbristol.ac.uk/privacy-statement/" target="_blank" rel="noopener noreferrer">cityofbristol.ac.uk/privacy-statement</a>.</p>
                <p>As Data Controller, the College may share non-sensitive personal information with other organisations as set out on its Data Protection registration and from 25 May 2018, General Data Protection Regulation. The College may share your information with other organisations for education, training, employment, research and well-being related purposes. Further details are available on the <a href="https://www.cityofbristol.ac.uk/privacy-statement/" target="_blank" rel="noopener noreferrer">College privacy statement</a>.</p>
                <p>If at any time you wish to stop receiving these messages, please contact Student Services on 0117 312 5000 or <a href="mailto:enquiries@cityofbristol.ac.uk">enquiries@cityofbristol.ac.uk</a> and change your preferences or opt-out at any time.</p>
                <p><strong>Sensitive information:</strong> The College may use this information to ensure equality of opportunity, support your studies, minimise risk and for anonymous statistics. We are required to share it with the relevant government departments as mentioned above. We will ask you before sharing it with others.</p>
            </article>
        </div>
    </section>
    `
      },
    {
        title: "Student Declaration",
    description:
            "Review and complete your student declaration.",
        url:
            "/webenrolment.aspx?page=~/webcontrols/v2.0/studentdeclaration.ascx&OfferingID=179330",
    content: `

    <form id="student-declaration-form" novalidate>
        <section class="form-section">
            <h2>Student Declaration</h2>
            <p class="section-help">Please complete your declaration and add your signature below.</p>

            <div class="form-group full-width">
                <label for="student-declaration">Declaration</label>
                <textarea
                    class="declaration-textarea"
                    id="student-declaration"
                    name="studentDeclaration"
                    placeholder="Enter your declaration here..."></textarea>
            </div>

            <div class="signature-wrap">
                <label class="field-label" for="signature-pad">Signature</label>
                <p class="form-hint">Sign in the box using your mouse, trackpad, finger or stylus.</p>

                <div class="signature-pad-shell" id="signature-pad-shell">
                    <canvas id="signature-pad" aria-label="Student signature pad"></canvas>
                    <div class="signature-line"></div>
                    <div class="signature-label">Sign above this line</div>
                </div>

                <div class="signature-actions">
                    <button class="btn" id="clear-signature" type="button">Clear Signature</button>
                </div>
                <input type="hidden" id="signature-data" name="signatureData">
            </div>
        </section>
    </form>
    `
      },
    
    ];

    let currentStep = 0;
    const urlParams = new URLSearchParams(window.location.search);
    const myParam = urlParams.get('page');
    

    if (myParam.startsWith("~/webcontrols/v2.0/applicationguidance.ascx"))
            currentStep = 0;
    if (myParam.startsWith("~/webcontrols/v2.0/personaldetails.ascx"))
            currentStep = 1;
    if (myParam.startsWith("~/webcontrols/v2.0/contactdetails.ascx"))
            currentStep = 2;
    if (myParam.startsWith("~/webcontrols/v2.0/parentcarercontactdetails.ascx"))
            currentStep = 3;
    if (myParam.startsWith("~/webcontrols/v2.0/residencystatus.ascx"))
            currentStep = 4;
    if (myParam.startsWith("~/webcontrols/v2.0/yourqualifications.ascx"))
            currentStep = 5;
    if (myParam.startsWith("~/webcontrols/v2.0/personalstatement.ascx"))
            currentStep = 6;
    if (myParam.startsWith("~/webcontrols/v2.0/learningdifficultyanddisability.ascx"))
            currentStep = 7;
    if (myParam.startsWith("~/webcontrols/v2.0/additionaldetails.ascx"))
            currentStep = 8;
    if (myParam.startsWith("~/webcontrols/v2.0/previousconvictions.ascx"))
            currentStep = 9;
    if (myParam.startsWith("~/webcontrols/v2.0/privacynotices.ascx"))
            currentStep = 10;
    if (myParam.startsWith("~/webcontrols/v2.0/studentdeclaration.ascx"))
            currentStep = 11;
    if (myParam.startsWith("~/webcontrols/v2.0/preview.ascx"))
            currentStep = 11;

    const stepper = document.getElementById("stepper");
    const content = document.getElementById("step-content");
    const breadcrumb = document.getElementById("breadcrumb-current");
    const previous = document.getElementById("previous");
    const next = document.getElementById("next");
    const progressText = document.getElementById("progress-text");


    function render() {
        const breadcrumbCurrent = document.getElementById("breadcrumb-current");

        const step = steps[currentStep];
        breadcrumbCurrent.innerHTML = step.title;

        steps.forEach((step, index) => {
            
        });

        renderStepper()

    }



function renderStepper() {
        const stepper = document.getElementById("stepper");
        const breadcrumbCurrent = document.getElementById("breadcrumb-current");
        stepper.innerHTML = "";

        steps.forEach((step, index) => {
            const item = document.createElement("div");
            //console.log(step);

            item.className = "step";
            item.setAttribute("role", "button");
            item.setAttribute("tabindex", "0");
            item.setAttribute("aria-label", `Go to step ${index + 1}: ${step.title}`);
            item.setAttribute("data-url", step.url)

            if (index === currentStep) {
                item.classList.add("active");
                item.setAttribute("aria-current", "step");
            }

            if (index < currentStep) {
                item.classList.add("completed");
            }

            item.innerHTML = `
              <div class="step-number">
                ${index < currentStep ? "✓" : index + 1}
              </div>
              <span class="step-label">${step.title}</span>
            `;

            //item.addEventListener("click", (event) => {
            //    //render();
            //    //console.log(step.url);
            //    window.location.href = step.url
            //});

            item.addEventListener("keydown", (event) => {

                event.preventDefault();
                render();

            });

            stepper.appendChild(item);
        });
    }