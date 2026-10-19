<%@ Control Language="VB" AutoEventWireup="false" CodeFile="thankyou_application.ascx.vb" Inherits="webcontrols_thankyou_applications" %>

<style>
.thankyou-page{
      max-width:1180px;margin:0 auto;padding:12px 0 6px;
    }
    .thankyou-hero{
      
      align-items:center;gap:42px;padding:34px 36px;
      border:1px solid #e5edf8;border-radius:20px;
      background:linear-gradient(135deg,#ffffff 0%,#f8fbff 100%);
      box-shadow:0 12px 35px rgba(23,43,77,.07);
    }
    .submitted-pill{
      display:inline-flex;align-items:center;gap:9px;padding:9px 14px;
      border-radius:999px;background:#dcfce7;color:#166534;
      font-size:14px;font-weight:700;margin-bottom:20px;
    }
    .submitted-check{
      display:grid;place-items:center;width:22px;height:22px;border-radius:50%;
      background:#16a34a;color:#fff;font-size:14px;
    }
    .thankyou-copy h2{
      margin:0 0 10px;font-size:46px;line-height:1.05;letter-spacing:-.025em;color:#0f2d52;
    }
    .thankyou-lead{
      margin:0 0 22px;color:#172b4d;font-size:19px;font-weight:600;line-height:1.5;
    }
    .thankyou-copy p:not(.thankyou-lead){
      margin:0 0 12px;color:#52657e;font-size:15px;line-height:1.7;
    }
    .thankyou-visual{
      position:relative;overflow:hidden;border-radius:16px;min-height:320px;
      background:#eef6ff;
    }
    .thankyou-visual img{
      display:block;width:100%;height:100%;min-height:320px;object-fit:cover;
      object-position:70% 37%;
      transform:scale(1.06);
    }
    .thankyou-info{
      display:grid;grid-template-columns:1fr 1fr;margin-top:22px;
      border:1px solid #dbeafe;border-radius:18px;overflow:hidden;background:#f6faff;
    }
    .thankyou-info-card{
      display:grid;grid-template-columns:48px minmax(0,1fr);gap:16px;padding:26px 28px;
    }
    .thankyou-info-card + .thankyou-info-card{border-left:1px solid #dbeafe}
    .thankyou-icon{
      display:grid;place-items:center;width:48px;height:48px;border-radius:50%;
      background:#dbeafe;color:#2563eb;font-size:22px;font-weight:700;
    }
    .thankyou-info-card h3{margin:2px 0 8px;color:#172b4d;font-size:19px}
    .thankyou-info-card p{margin:0 0 8px;color:#52657e;font-size:14px;line-height:1.65}
    .thankyou-contact{margin-top:10px!important;color:#172b4d!important;font-weight:600}
    .thankyou-contact a{color:#2563eb;text-decoration:none;overflow-wrap:anywhere}
    .thankyou-contact a:hover{text-decoration:underline}
    .thankyou-footer-action{display:flex;justify-content:center;margin-top:24px}
    .return-site-btn{
      display:inline-flex;align-items:center;justify-content:center;gap:9px;
      min-width:240px;padding:13px 22px;border-radius:999px;
      background:#2563eb;color:#fff;text-decoration:none;font-weight:700;
      box-shadow:0 7px 18px rgba(37,99,235,.18);
    }
    .return-site-btn:hover{background:#1d4ed8}
    @media(max-width:900px){
      .thankyou-hero{grid-template-columns:1fr;padding:28px}
      .thankyou-visual{min-height:280px}
      .thankyou-visual img{min-height:280px}
      .thankyou-copy h2{font-size:40px}
    }
    @media(max-width:700px){
      .thankyou-page{padding:0}
      .thankyou-hero{padding:22px;border-radius:14px;gap:26px}
      .thankyou-copy h2{font-size:36px}
      .thankyou-lead{font-size:17px}
      .thankyou-visual{min-height:230px}
      .thankyou-visual img{min-height:230px}
      .thankyou-info{grid-template-columns:1fr}
      .thankyou-info-card{padding:22px 20px}
      .thankyou-info-card + .thankyou-info-card{border-left:0;border-top:1px solid #dbeafe}
    }
.stepper{
	display: none !important
}

</style>
<!--<br />
<h2 class="alert alert-success">
    Online submission complete</h2>


<p> Thank you for sending your details to City of Bristol College. We will contact you shortly regarding the next steps! </p>-->

<div class="thankyou-page">
	<section class="thankyou-hero">
	  <div class="thankyou-copy">
		<div class="submitted-pill"><span class="submitted-check">✓</span> Application submitted</div>
		<h2>Thank you!</h2>
		<p class="thankyou-lead">Your application has been submitted successfully.</p>
		<p>You will receive an acknowledgement email once it has been processed.</p>
		<p>Our Admissions Team will contact you by email or phone if any additional information is required. We will also keep you updated on the progress of your application.</p>
	  </div>
	  
	</section>

	<section class="thankyou-info" aria-label="Important application information">
	  <div class="thankyou-info-card">
		<div class="thankyou-icon" aria-hidden="true">✉</div>
		<div>
		  <h3>IMPORTANT!</h3>
		  <p>We communicate about applications by email, so please check your inbox for updates and add us to your safe senders list.</p>
		  <p>If you are not receiving emails from us, please check your junk, spam and promotions folders. You can also contact us to confirm that we have your correct email address.</p>
		</div>
	  </div>

	  <div class="thankyou-info-card">
		<div class="thankyou-icon" aria-hidden="true">☎</div>
		<div>
		  <h3>Need help?</h3>
		  <p>If you have any questions about your application, please contact our Student Services team.</p>
		  <p class="thankyou-contact">0117 312 5000</p>
		  <p class="thankyou-contact"><a href="mailto:enquiries@cityofbristol.ac.uk">enquiries@cityofbristol.ac.uk</a></p>
		</div>
	  </div>
	</section>

	<div class="thankyou-footer-action">
	  <a class="return-site-btn" href="https://www.cityofbristol.ac.uk/">Return to our website ↗</a>
	</div>
</div>