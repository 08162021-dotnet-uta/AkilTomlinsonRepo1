
//(function(){
//    fetch("customer/GetCustomers")
//    .then(res => res.json())
//    .then(data => console.log(data))
//})();

(function () {
  fetch("customer/GetCustomers")
    .then(res => res.json())
    .then(data => {
      console.log(data)
      const cust = document.querySelector('.listofcustomers');
      for (let x = 0; x < data.length; x++) {
        cust.innerHTML += `<p>The customer is ${data[x].firstName} ${data[x].lastName}.</p>`;
      }
    });
})();