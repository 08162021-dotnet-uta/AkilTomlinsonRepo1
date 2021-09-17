const store = JSON.parse(sessionStorage.getItem('storeId'));
const ordertotal = document.querySelector('.ordertotal');
//console.log(store);

(function () {
  fetch(`product/GetProducts/${store}`)
    .then(res => res.json())
    .then(data => {
      //console.log(data)
      const store = document.querySelector('.listofproducts');
      for (let x = 0; x < data.length; x++) {
        store.innerHTML += `<li class="product" onclick="ProductSelect(${data[x].productId})"> ${data[x].productName}: ${data[x].productDescription} - $${data[x].productPrice}</li>`;
      }
      sessionStorage.setItem('orderTotal', 0);
      var myOrder = '[{"productId":0, "Qty":0, "productName":0, "productPrce":0}]';
      // var myOrder = new Array(100);
      // console.log(myOrder.length)

      sessionStorage.setItem('currentOrder', myOrder);
      // const myObj = JSON.parse(myOrder);
      // console.log(myObj[0]);


    });
})();

const productitem = document.querySelector('.cart');
function ProductSelect(productId) {
  fetch(`product/GetProductData/${productId}`)
    .then(res => res.json())
    .then(data => {
      //console.log(data)
      var total = sessionStorage.getItem('orderTotal');
      var total1 = parseFloat(data.productPrice) + parseFloat(total);
      sessionStorage.setItem('orderTotal', total1);

      var currentOrder = JSON.parse(sessionStorage.getItem('currentOrder'));

      // console.log(currentOrder);
      var existingProduct = false;
      for (let x = 0; x < currentOrder.length; x++) {
        //  console.log(currentOrder[x].productId);
        // console.log(data.productId);
        if (currentOrder[x].productId == data.productId) {
          currentOrder[x].Qty++;
          existingProduct = true;
          break;
        }


      }

      if (!existingProduct) {
        var orderString = { "productId": + `${data.productId}`, 'Qty': 1, "productName": `${data.productName}`, "productPrice": `${data.productPrice}` }
        currentOrder.push(orderString)
      }
      sessionStorage.setItem('currentOrder', JSON.stringify(currentOrder))
      //console.log(currentOrder);

      productitem.innerHTML = `<p>Cart<p>`
      for (let x = 1; x < currentOrder.length; x++) {

        productitem.innerHTML += `<li> ${currentOrder[x].productName} - Price: ${currentOrder[x].productPrice} Qty: ${currentOrder[x].Qty} </li>`
      }


      //productitem.innerHTML += `<li> ${data.productName} - $${data.productPrice}</li>`



      ordertotal.innerHTML = total1;
    });
};

const ordersubmit = document.querySelector(".ordersubmit")

ordersubmit.addEventListener("submit", (e) => {
  e.preventDefault()
  const user = JSON.parse(sessionStorage.getItem('user'));

  fetch(`order/CreateOrder/${user.customerId}/${store}`)
    // fetch("customer/GetCustomers")
    .then(res => {
      // console.log(res);
      if (!res.ok) {
        console.log('unable to create order')
        throw new Error(`Network response was not ok (${res.status})`);
      }
      return res.json();
    })
    .then(res => {
      // console.log(res);
      sessionStorage.setItem('orderId', JSON.stringify(res.result));
      // result = res.result
      // sessionStorage.setItem('orderId', res.result);

      console.log(sessionStorage.user);

    })
    .catch(err => console.log(`There was an error ${err}`));

  var currentOrder = JSON.parse(sessionStorage.getItem('currentOrder'));
  var orderNumber = sessionStorage.getItem('orderId');

  for (let x = 1; x < currentOrder.length; x++) {
    fetch(`order/PopulateOrder/${orderNumber}/${currentOrder[x].productId}/${currentOrder[x].Qty}`)
      .then(res => {
        // console.log(res);
        // if (!res.ok) {
        //   console.log('unable to add item to order')
        //   throw new Error(`Network response was not ok (${res.status})`);
        // }
        // return res.json();
      })
      .then(res => {
        // console.log(res);
        // sessionStorage.setItem('orderId', JSON.stringify(res));

      })
      .catch(err => console.log(`There was an error ${err}`));
  }

});

function SeeStoreOrders() {
  location.href = "storeorders.html";
}
