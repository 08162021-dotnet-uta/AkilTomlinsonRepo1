const welcome = document.querySelector('.welcome');

if (!sessionStorage.user) {
  location.href = "index.html";
}
else {
  //console.log(sessionStorage.user.fname);
  let user = JSON.parse(sessionStorage.getItem('user'));
  console.log(user);
  welcome.innerHTML = `${user.firstName}`;


  (function () {
    fetch("store/GetStores")
      .then(res => res.json())
      .then(data => {
        console.log(data)
        const store = document.querySelector('.listofstores');
        for (let x = 0; x < data.length; x++) {
          store.innerHTML += `<li>Store ${data[x].storeId} is ${data[x].storeName}.</li>`;
        }
      });
  })();
}