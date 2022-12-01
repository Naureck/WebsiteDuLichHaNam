
   try { var storTest = window['localStorage'];
   storTest.setItem("", ".");
  storTest.removeItem(""); }
  catch(e) {alert("Please go away"); }