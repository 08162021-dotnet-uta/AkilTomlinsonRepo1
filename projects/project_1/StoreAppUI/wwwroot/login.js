const loginform = document.querySelector(".loginform");

loginform.addEventListener("submit", (e) => {
  e.preventDefault()
  const FirstName = loginform.FirstName.value;
  const LastName = loginform.LastName.value;

  fetch(`customer/login/${FirstName}/${LastName}`)
    .then(res => {
      //console.log(res);
      if (!res.ok) {
        console.log('unable to login the user')
        throw new Error(`Network response was not ok (${res.status})`);
      }
      return res.json();
    })
    .then(res => {
      //console.log(res);
      sessionStorage.setItem('user', JSON.stringify(res));

      console.log(sessionStorage.user);
      //sessionStorage.clear()

      location.href = "store-list.html";

    })
    .catch(err => console.log(`There was an error ${err}`));
});