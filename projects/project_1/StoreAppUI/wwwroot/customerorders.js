const customer = JSON.parse(sessionStorage.getItem('user'));

(function () {
  fetch(`customer/GetCustOrders/${customer.customerId}`)
    .then(res => res.json())
    .then(data => {
      //console.log(data)
      const cust = document.querySelector('.customerorders');
      for (let x = 0; x < data.length; x++) {
        cust.innerHTML += `<p>Order ${data[x].orderId}: ${data[x].firstName} ${data[x].productName}.</p>`;
      }
    });
})();