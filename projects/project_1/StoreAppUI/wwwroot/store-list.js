const welcome = document.querySelector('.welcome');
const storeselect = document.querySelector('.storename')

if (!sessionStorage.user) {
  location.href = "index.html";
}
else {
  //console.log(sessionStorage.user.fname);
  let user = JSON.parse(sessionStorage.getItem('user'));
  // console.log(user);
  welcome.innerHTML = `${user.firstName}`;


  (function () {
    fetch("store/GetStores")
      .then(res => res.json())
      .then(data => {
        // console.log(data)
        const store = document.querySelector('.listofstores');
        for (let x = 0; x < data.length; x++) {
          store.innerHTML += `<li class="storename" onclick="StoreSelect(${data[x].storeId})">Store ${data[x].storeId}: ${data[x].storeName}</li>`;
        }
      });
  })();
}
function StoreSelect(storeId) {

  sessionStorage.setItem('storeId', storeId);
  location.href = "store.html";
}

function SeeCustomerOrders() {
  location.href = "customerorders.html";
}
//storeselect.addEventListener('click')