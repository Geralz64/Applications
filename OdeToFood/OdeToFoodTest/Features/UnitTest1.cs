using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Models;

namespace OdeToFoodTest.Features
{
    [TestClass]
    public class UnitTest1
    {





        [TestMethod]
        public void Computes_Result_For_Two_Reviews()
        {

            var data = BuildRestaurantAndReviews(ratings: new[] { 4, 8 });

            var rater = new RestaurantRater(data);

            var result = rater.ComputeResult(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(6, result.Rating);
        }



        [TestMethod]
        public void Weighted_Averaging_For_Two_Reviews()
        {

            var data = BuildRestaurantAndReviews( 3, 9);

            var rater = new RestaurantRater(data);

            var result = rater.ComputeResult(new WeightedAlgorithm(), 10);

            Assert.AreEqual(6, result.Rating);
        }


        private Restaurant BuildRestaurantAndReviews(params int[] ratings)
        {

            var restaurant = new Restaurant();

            restaurant.Reviews = ratings.Select(r => new RestaurantReview { Rating = r })
                                    .ToList();

            return restaurant;
        }


        [TestMethod]
        public void Weighted_Averagin_For_Two_Reviews()
        {




        }
    }

}
