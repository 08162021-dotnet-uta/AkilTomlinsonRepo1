const store = JSON.parse(sessionStorage.getItem('storeId'));

(function () {
  fetch(`store/GetStoreOrders/${store}`)
    .then(res => res.json())
    .then(data => {
      //  console.log(data)
      const cust = document.querySelector('.storeorders');
      for (let x = 0; x < data.length; x++) {
        cust.innerHTML += `<p>Order ${data[x].orderId}: ${data[x].firstName} ${data[x].productName}.</p>`;
      }
    });
})();